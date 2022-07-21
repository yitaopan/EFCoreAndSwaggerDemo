using EFCoreAndSwaggerDemo.Models.Resource;
using EFCoreAndSwaggerDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAndSwaggerDemo.Controllers.AsyncOperation
{
    [ApiController]
    public abstract class BaseAsyncOperationResultController : BaseApiController
    {
        private readonly IAsyncOperationService _asyncOperationService;

        public BaseAsyncOperationResultController(IAsyncOperationService asyncOperationService)
        {
            _asyncOperationService = asyncOperationService;
        }

        public abstract Task<object> GetResourceAsyncOperationResult(ResourceSpec spec,
            string location, string operationId, CancellationToken cancellationToken);

        public abstract Task<object> GetSubscriptionAsyncOperationResult(string subscriptionId, 
            string operationId, CancellationToken cancellationToken);

        public abstract Task<object> GetProviderAsyncOperationResult(string operationId, 
            CancellationToken cancellationToken);

        protected async Task<object> GetAsyncOperationResult(string operationId, 
            Func<ActionResult> handleNonTerminalStatus, CancellationToken cancellationToken)
        {
            var op = await _asyncOperationService.GetAsync(operationId, cancellationToken);
            if (op == null)
            {
                return NotFound();
            }

            return "GetAsyncOperationResult";
        }
    }
}
