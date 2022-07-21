using EFCoreAndSwaggerDemo.Models.Entities.AsyncOperation;
using EFCoreAndSwaggerDemo.Models.Entities.AsyncOperation.AsyncOperationType;
using EFCoreAndSwaggerDemo.Models.Resource;
using EFCoreAndSwaggerDemo.Repositories;

namespace EFCoreAndSwaggerDemo.Services
{
    public interface IAsyncOperationService
    {
        Task<AsyncOperationEntity> CreateAsync(AbstractAsyncOperationType type, 
            CancellationToken cancellationToken);

        Task<AsyncOperationEntity> CreateAsync(AbstractAsyncOperationType type, 
            string subscriptionId, CancellationToken cancellationToken);

        Task<AsyncOperationEntity> CreateAsync(AbstractAsyncOperationType type, 
            ResourceSpec resourceSpec, CancellationToken cancellationToken);

        Task<AsyncOperationEntity?> GetAsync(string operationId,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<AsyncOperationEntity> UpdateSucceededAsync(string subscriptionId, string operationId,
            CancellationToken cancellationToken = default);

        Task<AsyncOperationEntity> UpdateFailedAsync(string subscriptionId, string operationId, string errorCode,
            string errorMessage, CancellationToken cancellationToken = default(CancellationToken));

        Task<AsyncOperationEntity> UpdateCancelledAsync(string subscriptionId, string operationId, string errorCode,
            string errorMessage, CancellationToken cancellationToken = default(CancellationToken));

    }

    public class AsyncOperationService : IAsyncOperationService
    {
        private readonly IAsyncOperationRepository _asyncOperationRepository;

        public AsyncOperationService(IAsyncOperationRepository asyncOperationRepository)
        {
            _asyncOperationRepository = asyncOperationRepository;
        }

        public async Task<AsyncOperationEntity> CreateAsync(AbstractAsyncOperationType type, 
            CancellationToken cancellationToken)
        {
            var asyncOperation = await _asyncOperationRepository.CreateAsync(type, cancellationToken);
            return asyncOperation;
        }

        public async Task<AsyncOperationEntity> CreateAsync(AbstractAsyncOperationType type, 
            string subscriptionId, CancellationToken cancellationToken)
        {
            var asyncOperation = await _asyncOperationRepository.CreateAsync(type, subscriptionId, cancellationToken);
            return asyncOperation;
        }

        public async Task<AsyncOperationEntity> CreateAsync(AbstractAsyncOperationType type, 
            ResourceSpec resourceSpec, CancellationToken cancellationToken)
        {
            var asyncOperation = await _asyncOperationRepository.CreateAsync(type, resourceSpec, cancellationToken);
            return asyncOperation;
        }

        public async Task<AsyncOperationEntity?> GetAsync(string operationId, 
            CancellationToken cancellationToken)
        {
            var asyncOperation = await _asyncOperationRepository.GetAsync(operationId, cancellationToken);
            return asyncOperation;
        }

        public async Task<AsyncOperationEntity> UpdateSucceededAsync(string subscriptionId,
            string operationId, CancellationToken cancellationToken)
        {
            var asyncOperation = await _asyncOperationRepository.UpdateSucceededAsync(operationId, cancellationToken);
            return asyncOperation;
        }

        public async Task<AsyncOperationEntity> UpdateCancelledAsync(string subscriptionId, 
            string operationId, string errorCode, string errorMessage, CancellationToken cancellationToken)
        {
            var asyncOperation = await _asyncOperationRepository.UpdateCancelledAsync(operationId, 
                errorCode, errorMessage, cancellationToken);
            return asyncOperation;
        }

        public async Task<AsyncOperationEntity> UpdateFailedAsync(string subscriptionId, 
            string operationId, string errorCode, string errorMessage, CancellationToken cancellationToken)
        {
            var asyncOperation = await _asyncOperationRepository.UpdateFailedAsync(operationId, 
                errorCode, errorMessage, cancellationToken);
            return asyncOperation;
        }
    }
}
