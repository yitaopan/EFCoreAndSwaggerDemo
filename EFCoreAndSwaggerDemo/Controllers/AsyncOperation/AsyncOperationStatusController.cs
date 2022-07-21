using EFCoreAndSwaggerDemo.Common;
using EFCoreAndSwaggerDemo.Models.Resource;
using EFCoreAndSwaggerDemo.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EFCoreAndSwaggerDemo.Controllers.AsyncOperation
{
    public class AsyncOperationStatusController : BaseAsyncOperationStatusController
    {
        public AsyncOperationStatusController(IAsyncOperationService asyncOperationService)
            : base(asyncOperationService)
        {
        }

        [HttpGet]
        [Route(RouteConstants.ProviderAsyncOperationStatusPath)]
        public override Task<object> GetProviderAsyncOperationStatus(
            [Required][FromRoute] string operationId, 
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route(RouteConstants.AsyncOpStatusPath)]
        public override Task<object> GetResourceAsyncOperationStatus(
            [Required][FromRoute] ResourceSpec resourceId,
            [Required][FromRoute] string location,
            [Required][FromRoute] string operationId, 
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route(RouteConstants.SubscriptionAsyncOpStatusPath)]
        public override Task<object> GetSubscriptionAsyncOperationStatus(
            [Required][FromRoute] string subscriptionId,
            [Required][FromRoute] string operationId, 
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
