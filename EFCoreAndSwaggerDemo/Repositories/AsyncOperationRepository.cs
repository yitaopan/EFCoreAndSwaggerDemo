using EFCoreAndSwaggerDemo.Data.RP;
using EFCoreAndSwaggerDemo.Models.Entities.AsyncOperation;
using EFCoreAndSwaggerDemo.Models.Entities.AsyncOperation.AsyncOperationType;
using EFCoreAndSwaggerDemo.Models.Resource;

namespace EFCoreAndSwaggerDemo.Repositories
{
    public interface IAsyncOperationRepository
    {
        Task<AsyncOperationEntity> CreateAsync(AbstractAsyncOperationType type, 
            CancellationToken cancellationToken);

        Task<AsyncOperationEntity> CreateAsync(AbstractAsyncOperationType type, 
            string subscriptionId, CancellationToken cancellationToken);

        Task<AsyncOperationEntity> CreateAsync(AbstractAsyncOperationType type,
            ResourceSpec resourceSpec, CancellationToken cancellationToken);

        Task<AsyncOperationEntity?> GetAsync(string operationId,
            CancellationToken cancellationToken);

        Task<AsyncOperationEntity> UpdateSucceededAsync(string operationId, 
            CancellationToken cancellationToken);

        Task<AsyncOperationEntity> UpdateFailedAsync(string operationId,
            string errorCode, string errorMessage, CancellationToken cancellationToken);

        Task<AsyncOperationEntity> UpdateCancelledAsync(string operationsId, 
            string errorCode, string errorMessage, CancellationToken cancellationToken);
    }

    public class AsyncOperationRepository : IAsyncOperationRepository
    {
        private readonly RPContext _context;

        public AsyncOperationRepository(RPContext context)
        {
            _context = context;
        }

        public async Task<AsyncOperationEntity> CreateAsync(AbstractAsyncOperationType type,
            CancellationToken cancellationToken)
        {
            var op = new AsyncOperationEntity
            {
                OperationType = type,
                Id = Guid.NewGuid().ToString(),
            };
            try
            {
                _context.Add(op);
                await _context.SaveChangesAsync(cancellationToken);
                return op;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<AsyncOperationEntity> CreateAsync(AbstractAsyncOperationType type, 
            string subscriptionId, CancellationToken cancellationToken)
        {
            var op = new AsyncOperationEntity
            {
                OperationType = type,
                Id = Guid.NewGuid().ToString(),
                SubscriptionId = subscriptionId,
            };
            try
            {
                _context.Add(op);
                await _context.SaveChangesAsync(cancellationToken);
                return op;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<AsyncOperationEntity> CreateAsync(AbstractAsyncOperationType type, 
            ResourceSpec resourceSpec, CancellationToken cancellationToken)
        {
            var op = new AsyncOperationEntity
            {
                OperationType = type,
                Id = Guid.NewGuid().ToString(),
                ResourceGroup = resourceSpec.ResourceGroupName,
                ResourceId = resourceSpec.Id,
                SubscriptionId = resourceSpec.SubscriptionId,
                ResourceName = resourceSpec.ResourceName
            };
            try
            {
                _context.Add(op);
                await _context.SaveChangesAsync(cancellationToken);
                return op;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<AsyncOperationEntity?> GetAsync(string operationId, 
            CancellationToken cancellationToken)
        {
            if (_context.AsyncOperationEntities == null)
            {
                throw new NotImplementedException();
            }
            var asyncOperation = await _context.AsyncOperationEntities
                .FindAsync(operationId, cancellationToken);
            return asyncOperation;
        }

        public async Task<AsyncOperationEntity> UpdateSucceededAsync(string operationId,
            CancellationToken cancellationToken)
        {
            var asyncOperation = await GetAsync(operationId, cancellationToken);
            if (asyncOperation == null)
            {
                throw new NotImplementedException();
            }
            asyncOperation.Status = AsyncOperationStatus.Succeeded;
            try
            {
                _context.Update(asyncOperation);
                await _context.SaveChangesAsync();
                return asyncOperation;
            }
            catch
            {
                throw new NotImplementedException(); 
            }
        }

        public async Task<AsyncOperationEntity> UpdateCancelledAsync(string operationId, 
            string errorCode, string errorMessage, CancellationToken cancellationToken)
        {
            return await UpdateErrorAsync(operationId, AsyncOperationStatus.Cancelled, 
                errorCode, errorMessage, cancellationToken);
        }

        public async Task<AsyncOperationEntity> UpdateFailedAsync(string operationId, 
            string errorCode, string errorMessage, CancellationToken cancellationToken)
        {
            return await UpdateErrorAsync(operationId, AsyncOperationStatus.Failed,
                errorCode, errorMessage, cancellationToken);
        }

        private async Task<AsyncOperationEntity> UpdateErrorAsync(string operationId, AsyncOperationStatus status, 
            string errorCode, string errorMessage, CancellationToken cancellationToken)
        {
            var asyncOperation = await GetAsync(operationId, cancellationToken);
            if (asyncOperation == null)
            {
                throw new NotImplementedException();
            }
            asyncOperation.Status = status;
            asyncOperation.ErrorCode = errorCode;
            asyncOperation.ErrorMessage = errorMessage;
            try
            {
                _context.Update(asyncOperation);
                await _context.SaveChangesAsync();
                return asyncOperation;
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}
