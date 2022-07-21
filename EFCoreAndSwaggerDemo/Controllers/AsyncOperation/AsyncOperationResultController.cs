using EFCoreAndSwaggerDemo.Common;
using EFCoreAndSwaggerDemo.Models.Resource;
using EFCoreAndSwaggerDemo.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EFCoreAndSwaggerDemo.Controllers.AsyncOperation
{
    public class AsyncOperationResultController : BaseAsyncOperationResultController
    {
        public AsyncOperationResultController(IAsyncOperationService asyncOperationService) 
            : base(asyncOperationService)
        {
        }

        [HttpGet]
        [Route(RouteConstants.AsyncProviderOpResultPath)]
        public override Task<object> GetProviderAsyncOperationResult(
            [Required][FromRoute] string operationId,
            [Required][FromRoute] CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route(RouteConstants.AsyncResourceOpResultPath)]
        public override Task<object> GetResourceAsyncOperationResult(
            [Required][FromRoute] ResourceSpec spec,
            [Required][FromRoute] string location,
            [Required][FromRoute] string operationId, 
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route(RouteConstants.AsyncSubscriptionOpResultPath)]
        public override Task<object> GetSubscriptionAsyncOperationResult(
            [Required][FromRoute] string subscriptionId,
            [Required][FromRoute] string operationId, 
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
