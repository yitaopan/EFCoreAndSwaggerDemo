using EFCoreAndSwaggerDemo.Common.RichEnum;

namespace EFCoreAndSwaggerDemo.Models.Entities.AsyncOperation.AsyncOperationType
{
    [DynamicallyResolved]
    public abstract class AbstractAsyncOperationType : Enumeration
    {
        protected AbstractAsyncOperationType(int id, string name) : base(id, name)
        {

        }
    }
}
