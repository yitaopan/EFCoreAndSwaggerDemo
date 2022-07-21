using System.Text.RegularExpressions;

namespace EFCoreAndSwaggerDemo.Models.Resource
{
    public class ResourceSpec
    {
        public string SubscriptionId { get; set; }

        public string ResourceName { get; set; }

        public string Id { get; set; }

        public string ResourceGroupName { get; set; }
    }
}
