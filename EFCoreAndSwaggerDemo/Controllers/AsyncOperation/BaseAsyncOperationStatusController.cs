using EFCoreAndSwaggerDemo.Models.Resource;
using EFCoreAndSwaggerDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAndSwaggerDemo.Controllers.AsyncOperation
{
    [ApiController]
    public abstract class BaseAsyncOperationStatusController : BaseApiController
    {
        private readonly IAsyncOperationService _asyncOperationService;

        public BaseAsyncOperationStatusController(IAsyncOperationService asyncOperationService)
        {
            _asyncOperationService = asyncOperationService;
        }
        public abstract Task<object> GetResourceAsyncOperationStatus(ResourceSpec resourceId,
            string location, string operationId, CancellationToken cancellationToken);

        public abstract Task<object> GetSubscriptionAsyncOperationStatus(string subscriptionId,
            string operationId, CancellationToken cancellationToken);

        public abstract Task<object> GetProviderAsyncOperationStatus(string operationId,
            CancellationToken cancellationToken);

        protected async Task<object> GetAsyncOperationStatusAsync(string operationId, 
            string responseId, CancellationToken cancellationToken)
        {
            var op = await _asyncOperationService.GetAsync(operationId, cancellationToken);
            if (op == null)
            {
                return NotFound();
            }

            return "GetAsyncOperationStatusesAsync";
        }
    }
}
