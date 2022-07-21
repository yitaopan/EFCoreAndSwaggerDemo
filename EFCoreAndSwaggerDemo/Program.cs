using ContosoUniversity.Data;
using EFCoreAndSwaggerDemo.Data.RP;
using EFCoreAndSwaggerDemo.Repositories;
using EFCoreAndSwaggerDemo.Services;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// For Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});

// For Api Versioning
//builder.Services.AddApiVersioning(setup =>
//{
//    //setup.ApiVersionReader = new QueryStringApiVersionReader("api-version");
//    setup.ApiVersionReader = new QueryStringApiVersionReader();
//    setup.AssumeDefaultVersionWhenUnspecified = false;
//});

// For EF Core
builder.Services.AddDbContext<SchoolContext>(options 
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// For RP Database
builder.Services.AddDbContext<RPContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("RPDBConnection")));

// For Async Operations
builder.Services.AddScoped<IAsyncOperationService, AsyncOperationService>();
builder.Services.AddScoped<IAsyncOperationRepository, AsyncOperationRepository>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Create database if not exists
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<SchoolContext>();
        DbInitializer.Initialize(context);

        var rpContext = services.GetRequiredService<RPContext>();
        RPDbInitializer.Initialize(rpContext);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
