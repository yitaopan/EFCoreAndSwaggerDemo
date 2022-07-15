using EFCoreAndSwaggerDemo.Common;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAndSwaggerDemo.Controllers.v1
{
    [ApiController]
    //[ApiVersion(ApiVersions.v1)]
    [Route("api/test1")]
    public class HomeController : BaseApiController
    {
        [HttpGet]
        public string test()
        {
            return "This is API v1";
        }
    }
}
