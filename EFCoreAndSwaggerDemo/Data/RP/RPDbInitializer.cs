using EFCoreAndSwaggerDemo.Models.Entities.AsyncOperation;

namespace EFCoreAndSwaggerDemo.Data.RP
{
    public static class RPDbInitializer
    {
        public static void Initialize(RPContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Async Operations
            if (context.AsyncOperationEntities.Any())
            {
                return;
            }

            var asyncOperationEntities1 = new AsyncOperationEntity[]
            {
                new AsyncOperationEntity(),
                new AsyncOperationEntity()
            };
            foreach (var asyncOperationEntity in asyncOperationEntities1)
            {
                context.AsyncOperationEntities.Add(asyncOperationEntity);
            }
            context.SaveChanges();
        }
    }
}
