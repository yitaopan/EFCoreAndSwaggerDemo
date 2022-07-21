namespace EFCoreAndSwaggerDemo.Common
{
    public static class ResourceConstants
    {
        public const string ArmNamespace = "Microsoft.AppPlatform";
        public const string ArmServiceResourceType = "Spring";
        public const string ArmServiceFullResourceType = ArmNamespace + "/" + ArmServiceResourceType;
        public const string ArmLocationFullResourceType = ArmNamespace + "/locations";

        public const string ArmAppResourceType = "apps";
        public const string ArmAppFullResourceType = ArmServiceFullResourceType + "/" + ArmAppResourceType;
        public const string ArmDeploymentResourceType = "deployments";
        public const string ArmDeploymentCompleteResourceType = ArmServiceResourceType + "/" + ArmAppResourceType + "/" + ArmDeploymentResourceType;
        public const string ArmDeploymentFullResourceType = ArmAppFullResourceType + "/" + ArmDeploymentResourceType;
        public const string ArmBindingResourceType = "bindings";
        public const string ArmBindingFullResourceType = ArmAppFullResourceType + "/" + ArmBindingResourceType;
        public const string ArmConnectorPropResourceType = "connectorProps";
        public const string ArmConnectorPropFullResourceType = ArmDeploymentFullResourceType + "/" + ArmConnectorPropResourceType;

        public const string ArmCustomDomainResourceType = "domains";
        public const string ArmCustomDomainFullResourceType = ArmAppFullResourceType + "/" + ArmCustomDomainResourceType;

        public const string ArmCertificateResourceType = "certificates";
        public const string ArmCertificateFullResourceType = ArmServiceFullResourceType + "/" + ArmCertificateResourceType;

        public const string ArmStorageResourceType = "storages";
        public const string ArmStorageFullResourceType = ArmServiceFullResourceType + "/" + ArmStorageResourceType;

        public const string ArmDetectorsFullResourceType = ArmServiceFullResourceType + "/detectors";

        public const string ArmInsightsLogDefFullResourceType = ArmServiceFullResourceType + "/providers/Microsoft.Insights/logDefinitions";
        public const string ArmInsightsMetricDefFullResourceType = ArmServiceFullResourceType + "/providers/Microsoft.Insights/metricDefinitions";
        public const string ArmInsightsDiagSettingsResourceType = "/providers/Microsoft.Insights/diagnosticSettings";
        public const string ArmInsightsDiagSettingsFullResourceType = ArmServiceFullResourceType + ArmInsightsDiagSettingsResourceType;

        public const string ArmBuildServiceResourceType = "buildServices";
        public const string ArmBuildServiceFullResourceType = ArmServiceFullResourceType + "/" + ArmBuildServiceResourceType;
        public const string ArmBuildServiceAgentPoolResourceType = "agentPools";
        public const string ArmBuildServiceAgentPoolFullResourceType = ArmBuildServiceFullResourceType + "/" + ArmBuildServiceAgentPoolResourceType;
        public const string ArmBuildServiceBuildpackResourceType = "supportedBuildpacks";
        public const string ArmBuildServiceBuildpackFullResourceType = ArmBuildServiceFullResourceType + "/" + ArmBuildServiceBuildpackResourceType;
        public const string ArmBuildServiceStackResourceType = "supportedStacks";
        public const string ArmBuildServiceStackFullResourceType = ArmBuildServiceFullResourceType + "/" + ArmBuildServiceStackResourceType;
        public const string ArmBuildServiceDefaultResourceName = "default";
        public const string ArmBuildServiceDefaultBuilderResourceName = "default";
        public const string ArmBuildServiceDefaultAgentPoolResourceName = "default";
        public const string ArmBuildServiceBuilderResourceType = "builders";
        public const string ArmBuildServiceBuilderFullResourceType = ArmBuildServiceFullResourceType + "/" + ArmBuildServiceBuilderResourceType;
        public const string ArmBuildServiceBuildResourceType = "builds";
        public const string ArmBuildServiceBuildFullResourceType = ArmBuildServiceFullResourceType + "/" + ArmBuildServiceBuildResourceType;
        public const string ArmBuildServiceBuildResultResourceType = "results";
        public const string ArmBuildServiceBuildResultFullResourceType = ArmBuildServiceBuildFullResourceType + "/" + ArmBuildServiceBuildResultResourceType;
        public const string ArmBuildServiceBuildpacksBindingResourceType = "buildpackBindings";
        public const string ArmBuildServiceBuildpacksBindingFullResourceType = ArmBuildServiceFullResourceType + "/" + ArmBuildServiceBuildpacksBindingResourceType;
        public const string ArmBuildServiceBuilderBuildpacksBindingFullResourceType = ArmBuildServiceBuilderFullResourceType + "/" + ArmBuildServiceBuildpacksBindingResourceType;

        public const string ArmConfigServerDefaultResourceName = "default";
        public const string ArmConfigServerResourceType = "configServers";
        public const string ArmConfigServerFullResourceType = ArmServiceFullResourceType + "/" + ArmConfigServerResourceType;
        public const string ArmMonitoringSettingDefaultResourceName = "default";
        public const string ArmMonitoringSettingsResourceType = "monitoringSettings";
        public const string ArmMonitoringSettingsFullResourceType = ArmServiceFullResourceType + "/" + ArmMonitoringSettingsResourceType;

        public const string ArmAcsDefaultResourceName = "default";
        public const string ArmAcsResourceType = "configurationServices";
        public const string ArmAcsFullResourceType = ArmServiceFullResourceType + "/" + ArmAcsResourceType;

        public const string ArmServiceRegistryDefaultResourceName = "default";
        public const string ArmServiceRegistryResourceType = "serviceRegistries";
        public const string ArmServiceRegistryFullResourceType = ArmServiceFullResourceType + "/" + ArmServiceRegistryResourceType;

        public const string ArmApiPortalDefaultResourceName = "default";
        public const string ArmApiPortalResourceType = "apiPortals";
        public const string ArmApiPortalCustomDomainResourceType = "domains";
        public const string ArmApiPortalFullResourceType = ArmServiceFullResourceType + "/" + ArmApiPortalResourceType;
        public const string ArmApiPortalCustomDomainFullResourceType = ArmApiPortalFullResourceType + "/" + ArmApiPortalCustomDomainResourceType;

        public const string ArmGatewayDefaultResourceName = "default";
        public const string ArmGatewayResourceType = "gateways";
        public const string ArmScgRouteConfigResourceType = "routeConfigs";
        public const string ArmScgCustomDomainResourceType = "domains";
        public const string ArmGatewayFullResourceType = ArmServiceFullResourceType + "/" + ArmGatewayResourceType;
        public const string ArmScgRouteConfigFullResourceType = ArmGatewayFullResourceType + "/" + ArmScgRouteConfigResourceType;
        public const string ArmScgCustomDomainFullResourceType = ArmGatewayFullResourceType + "/" + ArmScgCustomDomainResourceType;

        public const string AksNamespace = "Microsoft.ContainerService";
        public const string AksResourceType = "managedClusters";
        public const string AksClusterFullResourceType = AksNamespace + "/" + AksResourceType;
        public const string AksAgentPoolResourceType = "agentPools";
        public const string AksAgentPoolFullResourceType = AksClusterFullResourceType + "/" + AksAgentPoolResourceType;
        public const string AksOrchestratorsResourceType = AksNamespace + "/locations/orchestrators";
        public const string AksOrchestratorType = "Kubernetes";
        public const string AksSkipAsmAzSecPack = "SkipASMAzSecPack";

        public const string AcrNamespace = "Microsoft.ContainerRegistry";
        public const string AcrResourceType = "registries";

        public const string AciFullResourceType = "Microsoft.Network/virtualNetworks";

        public const string StorageAccountNamespace = "Microsoft.Storage";
        public const string StorageAccountResourceType = "storageAccounts";
        public const string StorageAccountFullResourceType = StorageAccountNamespace + "/" + StorageAccountResourceType;
        public const string StorageAccountSharedIdentityResourceType = "sharedIdentities";
        public const string StorageAccountSharedIdentityFullResourceType = StorageAccountFullResourceType + "/" + StorageAccountSharedIdentityResourceType;

        public const string PrivateEndpointNamespace = "Microsoft.Network";
        public const string PrivateEndpointType = "privateEndpoints";
        public const string PrivateDnsZoneNamespace = "Microsoft.Network";
        public const string PrivateDnsZoneType = "privateDnsZones";
        public const string PublicIPNamespace = "Microsoft.Network";
        public const string PublicIPType = "publicIPAddresses";

        public const string DiskEncryptionSetNamespace = "Microsoft.Compute";
        public const string DiskEncryptionSetResourceType = "diskEncryptionSets";
        public const string DiskEncryptionSetFullResourceType = DiskEncryptionSetNamespace + "/" + DiskEncryptionSetResourceType;
        public const string DiskEncryptionSetSharedIdentityResourceType = "sharedIdentities";
        public const string DiskEncryptionSetSharedIdentityFullResourceType = DiskEncryptionSetFullResourceType + "/" + DiskEncryptionSetSharedIdentityResourceType;

        public const string VmssNamespace = "Microsoft.Compute";
        public const string VmssResourceType = "virtualMachineScaleSets";
        public const string VmssFullResourceType = VmssNamespace + "/" + VmssResourceType;

        public const string LogAnalyticsNamespace = "Microsoft.Operationalinsights";
        public const string LogAnalyticsResourceType = "workspaces";

        public const string DnsZoneNamespace = "Microsoft.Network";
        public const string DnsZoneResourceType = "dnszones";

        public const string NSGNamespace = "Microsoft.Network";
        public const string NSGResourceType = "networkSecurityGroups";

        public const int DefaultVmCount = 2;
        public const int MaxVmCount = 8;
        public const int CachedAKSInitCoreNum = 12;

        public const string KubernetesDefaultNamespace = "default";
        public const string KubernetesSystemNamespace = "kube-system";
        public const string KubernetesAscSystemNamespace = "asc-system";
        public const string KubernetesBuildServiceAcrSecretName = "build-service";

        // Quota constants
        public const int QuotaDefaultMaxInstances = 10;

        // This is a general pattern covering all Azure resources
        public const string ResourceIdPattern = @"/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/(?<resourceProvider>[^/]+)(/(?<resourceType>[^/]+)/(?<resourceName>[^/?]+))+";
        public const string AksResourceIdPattern = @"/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft\.ContainerService/managedClusters/(?<resourceName>[^/?]+)";
        public const string ServiceIdPattern = @"/(?<serviceId>[0-9A-F]{32})\b";
        public const string SubnetResourceIdPattern = @"/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/Microsoft\.Network/virtualNetworks/(?<vnetName>[^/]+)/subnets/(?<subnetName>[^/]+)";

        // ACI constants
        public const string VNetNamespace = "Microsoft.Network";
        public const string VNetResourceType = "virtualNetworks";
        public const string SubnetResourceType = "subnets";
        public const string AciSubnetName = "virtual-node-aci";
        public const string NodePoolSubnetName = "default";
        public const string ServiceCidr = "10.0.0.0/16";
        public const string DnsServer = "10.0.0.10";
        public const string DockerBridgeCidr = "172.17.0.1/16";
        public const string DefaultSubnetAddressPrefix = "10.240.0.0/16";
        public const string DefaultSystemSubnetPrefix = "10.240.0.0/16";
        public const string AciSubnetAddressPrefix = "10.241.0.0/16";
        public const string DefaultUserSubnetPrefix = "10.242.0.0/16";
        public const string AddressSpaceAddressPrefix = "10.0.0.0/8";
        public const string AciDelegationName = "aciDelegation";
        public const string DelegationServiceName = "Microsoft.ContainerInstance/containerGroups";
        public const string DelegationAction = "Microsoft.Network/virtualNetworks/subnets/action";

        // arch v3 Subnet CIDR design
        public const string DefaultSystemSubnetAddressPrefix = "10.1.0.0/16";
        public const int DefaultSystemSubnetMappingId = 1;
        public const string DefaultUserSubnetAddressPrefix = "10.11.0.0/16";
        public const int DefaultUserSubnetMappingId = 11;
        public const int MaxUserSubnetMappingId = 255;


        // Resource Naming Convention
        public const string ServiceNamingCharacterConventionRegex = "^[a-z0-9-]+$";
        public const string ServiceNamingPatternConventionRegex = "^[a-z].*[a-z0-9]$";
        public const string ServiceNamingConventionRegex = "^[a-z][a-z0-9-]{2,30}[a-z0-9]$";
        public const string AppNamingConventionRegex = "^[a-z][a-z0-9-]{2,30}[a-z0-9]$";
        public const string DeploymentNamingConventionRegex = "^[a-z][a-z0-9-]{2,30}[a-z0-9]$";
        public const string BindingNamingConventionRegex = "^[a-z][a-z0-9-]{2,30}[a-z0-9]$";
        public const string CertificateNamingConventionRegex = "^[a-z0-9-]{1,127}$";
        public const string StorageNamingConventionRegex = "^[a-z][a-z0-9-]{2,30}[a-z0-9]$";
        public const int MaxResourceNameLength = 32;
        public const int MinResourceNameLength = 4;

        // Provisioned resource group constants
        public const string ProvisionedResourceGroupTagName = "asc-service-name";
        public const string CachedAKSAssignedTagName = "asc-assigned-status";
        public const string VnetSystemClusterTagName = "system-cluster";
        public const string VnetUserClusterTagName = "user-cluster";
        public const string SystemClusterTagName = "system-cluster";
        public const string RuntimeClusterTagName = "runtime-cluster";
        public const string ASCVersion = "asc-version";

        // Managed Identity for user
        public const string PodIdentityNamespace = "user-pod-identity";
        public const string PodIdentityGroup = "aadpodidentity.k8s.io";
        public const string PodIdentityNmiServiceAccount = "aad-pod-id-nmi-service-account";
        public const string PodIdentityMicServiceAccount = "aad-pod-id-mic-service-account";
        public const string PodIdentityVersion = "v1";
        public const string AzureAssignedIdentityKind = "AzureAssignedIdentity";
        public const string AzureAssignedIdentityListKind = "AzureAssignedIdentityList";
        public const string AzureAssignedIdentityPlural = "azureassignedidentities";
        public const string AzureAssignedIdentitySingular = "azureassignedidentity";
        public const string AzureIdentityKind = "AzureIdentity";
        public const string AzureIdentityListKind = "AzureIdentityList";
        public const string AzureIdentityPlural = "azureidentities";
        public const string AzureIdentitySingular = "azureidentity";
        public const string AzureIdentityBindingKind = "AzureIdentityBinding";
        public const string AzureIdentityBindingListKind = "AzureIdentityBindingList";
        public const string AzureIdentityBindingPlural = "azureidentitybindings";
        public const string AzureIdentityBindingSingular = "azureidentitybinding";
        public const string AzurePodIdentityExceptionKind = "AzurePodIdentityException";
        public const string AzurePodIdentityExceptionListKind = "AzurePodIdentityExceptionList";
        public const string AzurePodIdentityExceptionPlural = "azurepodidentityexceptions";
        public const string AzurePodIdentityExceptionSingular = "azurepodidentityexception";
        public const string PodIdentityNmiClusterRole = "aad-pod-id-nmi-role";
        public const string PodIdentityNmiClusterRoleBinding = "aad-pod-id-nmi-binding";
        public const string PodIdentityMicClusterRole = "aad-pod-id-mic-role";
        public const string PodIdentityMicClusterRoleBinding = "aad-pod-id-mic-binding";
        public const string PodIdentitySecretOpaqueType = "Opaque";
        public const string PodIdentityCertificateKey = "certificate";

        // Data Plane
        public const string DataPlaneConfigServiceName = "configService";
        public const string DataPlaneEurekaServiceName = "eurekaService";
        public const string DataPlaneLogStreamServiceName = "logstreamService";
        public const string DataPlaneEncryptionServiceName = "encryptionService";

        public const string DataPlaneConfigServiceAction = ArmServiceFullResourceType + "/" + DataPlaneConfigServiceName;
        public const string DataPlaneEurekaServiceAction = ArmServiceFullResourceType + "/" + DataPlaneEurekaServiceName;
        public const string DataPlaneLogstreamServiceAction = ArmServiceFullResourceType + "/" + DataPlaneLogStreamServiceName;
        public const string DataPlaneEncryptionServiceAction = ArmServiceFullResourceType + "/" + DataPlaneEncryptionServiceName;

        // Cache constants
        public const int MinPoolSize = 0;
        public const int MaxPoolSize = 30;

        // Custom Probe constants
        public const int EnterpriseTierDefaultProbePort = 8080;
        public const int NonEnterpriseTierDefaultProbePort = 1025;

        public static class IngressConfig
        {
            public static class ReadTimeoutInSeconds
            {
                public const int Default = 300;
                public const int Max = 30 * 60;
                public const int Min = 1;
            }
        }

        // SKU
        public static class Sku
        {
            public static class Tier
            {
                public const string Basic = "Basic";
                public const string Standard = "Standard";
                public const string Enterprise = "Enterprise";
            }

            public static class Name
            {
                public const string B0 = "B0";
                public const string S0 = "S0";
                public const string E0 = "E0";
            }
        }

        // Build Agent Pool Tier
        public static class BuildAgentPoolConstants
        {
            public static class PoolSizeName
            {
                public const string S1 = "S1";
                public const string S2 = "S2";
                public const string S3 = "S3";
                public const string S4 = "S4";
                public const string S5 = "S5";
            }
        }

        // Storage SAS token
        public const string SasDefinition = "ascrp";
        public const string ReadonlySasDefinition = "readonly";
        public const string RpStorageKeyword = "rp";
        public const string BillingStorageKeyword = "bill";
        public const string QuotaStorageKeyword = "quota";
        public const string BackupStorageKeyword = "backup";

        public const int FallbackToConnectionStringAuthRetryThreshold = 4;

        // Global Unique Resource
        public const string GlobalUniqueResourceMetadataRegion = "Region";
        public const string GlobalUniqueResourceMetadataServiceInstanceResourceId = "ServiceInstanceResourceId";
    }
}
