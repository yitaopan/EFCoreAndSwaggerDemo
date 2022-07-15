using EFCoreAndSwaggerDemo.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EFCoreAndSwaggerDemo.Controllers
{
    public class BaseApiController : Controller, IActionFilter
    {
        public string ApiVersion { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var pair in Request.Query)
            {
                if (ApiVersions.ApiVersionQueryKey.Equals(pair.Key, StringComparison.OrdinalIgnoreCase))
                {
                    ApiVersion = pair.Value;
                    return;
                }
            }
        }
    }
}
