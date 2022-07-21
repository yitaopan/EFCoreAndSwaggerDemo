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
            string subscriptionId,CancellationToken cancellationToken);

        //Task<AsyncOperationEntity> Create(
        //    AbstractAsyncOperationType type,
        //    ResourceSpec resourceSpec,
        //    CancellationToken cancellationToken);

        Task<AsyncOperationRepository> UpdateSucceededAsync(string operationId, 
            CancellationToken cancellationToken);

        Task<AsyncOperationRepository> UpdateFailedAsync(string operationId,
            string errorCode, string errorMessage, CancellationToken cancellationToken);

        Task<AsyncOperationRepository> UpdateCancelledAsync(string operationsId, 
            string errorCode, string errorMessage, CancellationToken cancellationToken);

        Task<AsyncOperationRepository> GetAsync(string operationId,
            CancellationToken cancellationToken);
    }

    public class AsyncOperationRepository// : IAsyncOperationRepository
    {
        private readonly RPContext _context;

        public AsyncOperationRepository(RPContext context)
        {
            _context = context;
        }

        public async Task<AsyncOperationEntity> GetAsyncOperationEntityAsync(
            string operationId, CancellationToken cancellationToken)
        {
            if (_context.AsyncOperationEntities == null)
            {
                //throw new Exception();
            }
            var asyncOperation = await _context.AsyncOperationEntities
                .FindAsync(operationId, cancellationToken);
            if (asyncOperation == null)
            {
                //throw new Exception();
            }
            return asyncOperation;
        }
    }
}
