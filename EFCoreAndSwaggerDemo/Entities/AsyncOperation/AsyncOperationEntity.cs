using EFCoreAndSwaggerDemo.Models.Entities.AsyncOperation.AsyncOperationType;

namespace EFCoreAndSwaggerDemo.Models.Entities.AsyncOperation
{
    public class AsyncOperationEntity : BaseEntity
    {
        // The primary key should be random?
        public string Id { get; set; }

        public AsyncOperationStatus Status { get; set; }

        /* Deal with non-nullable
         * Reference:
         * https://docs.microsoft.com/en-us/ef/core/miscellaneous/nullable-reference-types
         * 
         * NullValueHandling = NullValueHandling.Ignore
         */
        public string? ResourceId { get; set; }

        public string? ResourceName { get; set; }

        public string? ResourceGroup { get; set; }

        public string? SubscriptionId { get; set; }

        public AbstractAsyncOperationType OperationType { get; set; }

        // Error Code and Error Message should have constrains according to Status?
        public string? ErrorCode { get; set; }

        public string? ErrorMessage { get; set; }

        /* TODO
         * Move to repository
         */
        //public bool IsStatusTerminal
        //{
        //    get { return AsyncOperationStatus.Running.Equals(Status); }
        //}

        /* Possible Missing Parts:
         * 1. AsyncOperationProperties.TriggeredBuildResults (Enterprise Tier)
         * 3. Dictionary<string, string> Extras
         * 4. Dictionary<string, List<string>> Checkpoint
         * 5. SubOperation Related
         */
    }

    /* Reference:
     * https://github.com/Azure/azure-resource-manager-rpc/blob/master/v1.0/async-api-reference.md#provisioningstate-property
     */
    public enum AsyncOperationStatus
    {
        // Terminal States
        Succeeded = 10,
        Failed = 11,
        Cancelled = 12,

        // Non-terminal States
        Running = 20,
    }
}
