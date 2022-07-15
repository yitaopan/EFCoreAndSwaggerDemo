using EFCoreAndSwaggerDemo.Common;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAndSwaggerDemo.Controllers.v2
{
    [ApiController]
    //[ApiVersion(ApiVersions.v2)]
    [Route("api/test2")]
    public class HomeController : BaseApiController
    {
        [HttpGet]
        public string test()
        {
            return "This is API v2";
        }
    }
}
