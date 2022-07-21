using static EFCoreAndSwaggerDemo.Common.ResourceConstants;

namespace EFCoreAndSwaggerDemo.Common
{
    public static class RouteConstants
    {
        public const string ArmSubscriptionsResourcesRoute =
            "/subscriptions/{subscriptionId}/providers/" + ArmServiceFullResourceType;

        public const string ArmResourcesRoute =
            "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/" + ArmServiceFullResourceType;

        public const string ArmServiceResourcesRoute = ArmResourcesRoute + "/{serviceName}";
        public const string ArmAppResourceCollectionRoute = ArmServiceResourcesRoute + "/apps";
        public const string ArmAppResourceRoute = ArmAppResourceCollectionRoute + "/{appName}";
        public const string ArmAppResourceSetActiveDeploymentActionRoute = ArmAppResourceRoute + "/setActiveDeployments";
        public const string ArmDeploymentResourceCollectionRoute = ArmAppResourceRoute + "/deployments";
        public const string ArmServiceDeploymentListRoute = ArmServiceResourcesRoute + "/deployments";
        public const string ArmDeploymentResourceRoute = ArmDeploymentResourceCollectionRoute + "/{deploymentName}";
        public const string ArmBindingResourceCollectionRoute = ArmAppResourceRoute + "/bindings";
        public const string ArmBindingResourceRoute = ArmBindingResourceCollectionRoute + "/{bindingName}";
        public const string ArmConnectorPropResourceCollectionRoute = ArmDeploymentResourceRoute + "/connectorProps";
        public const string ArmConnectorPropResourceRoute = ArmConnectorPropResourceCollectionRoute + "/{key}";
        public const string DetectorResourceCollectionRoute = ArmServiceResourcesRoute + "/detectors";
        public const string DetectorResourceRoute = DetectorResourceCollectionRoute + "/{detectorId}";
        public const string DiagnosticSettingsNotificationRoute = ArmServiceResourcesRoute + ResourceConstants.ArmInsightsDiagSettingsResourceType +
            "/{diagSettingsName}/providers/" + ArmNamespace + "/notify";
        public const string StopServiceRoute = "stop";
        public const string StartServiceRoute = "start";

        public const string ArmCustomDomainResourceCollectionRoute = ArmAppResourceRoute + "/domains";
        public const string ArmCustomDomainValidateRoute = ArmCustomDomainResourceCollectionRoute + "/validate";
        public const string ArmAppValidateCustomDomainRoute = ArmAppResourceRoute + "/validateDomain";
        public const string ArmCertificateResourceCollectionRoute = ArmServiceResourcesRoute + "/certificates";
        public const string ArmStorageResourceCollectionRoute = ArmServiceResourcesRoute + "/storages";

        public const string ArmCustomDomainResourceRoute = ArmCustomDomainResourceCollectionRoute + "/{domainName}";
        public const string ArmCertificateResourceRoute = ArmCertificateResourceCollectionRoute + "/{certificateName}";

        public const string ArmStorageResourceRoute = ArmStorageResourceCollectionRoute + "/{storageName}";

        public const string ArmConfigServerResourceRoute = ArmServiceResourcesRoute + "/" + ResourceConstants.ArmConfigServerResourceType + "/" + ResourceConstants.ArmConfigServerDefaultResourceName;
        public const string ArmConfigServerValidateRoute = ArmServiceResourcesRoute + "/configServers/validate";
        public const string ArmMonitoringSettingResourceRoute = ArmServiceResourcesRoute + "/" + ResourceConstants.ArmMonitoringSettingsResourceType + "/" + ResourceConstants.ArmMonitoringSettingDefaultResourceName;

        public const string ArmPreflightRequestResourceGroupRoute = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/" + ResourceConstants.ArmNamespace + "/deployments/{deploymentName}/preflight";
        public const string ArmPreflightRequestTenantRoute = "/providers/" + ResourceConstants.ArmNamespace + "/deployments/{deploymentName}/preflight";
        public const string ArmPreflightRequestSubscriptionRoute = "/subscriptions/{subscriptionId}/providers/" + ResourceConstants.ArmNamespace + "/deployments/{deploymentName}/preflight";
        public const string ArmPreflightRequestManagementGroupRoute = "/providers/Microsoft.Management/managementGroups/{managementGroupName}/providers/" + ResourceConstants.ArmNamespace + "/deployments/{deploymentName}/preflight";

        public const string UploadUrlResourceRoute = DefaultBuildServiceResourceRoute + "/getResourceUploadUrl";
        public const string BuildpackResourceCollectionRoute = DefaultBuildServiceResourceRoute + "/" + ArmBuildServiceBuildpackResourceType;
        public const string BuildpackResourceRoute = BuildpackResourceCollectionRoute + "/{buildpackName}";
        public const string StackResourceCollectionRoute = DefaultBuildServiceResourceRoute + "/" + ArmBuildServiceStackResourceType;
        public const string StackResourceRoute = StackResourceCollectionRoute + "/{stackName}";
        public const string BuildServiceResourceCollectionRoute = ArmServiceResourcesRoute + "/" + ArmBuildServiceResourceType;
        public const string BuildServiceResourceRoute = BuildServiceResourceCollectionRoute + "/{buildServiceName}";
        public const string BuilderResourceCollectionRoute = DefaultBuildServiceResourceRoute + "/" + ArmBuildServiceBuilderResourceType;
        public const string BuilderResourceRoute = BuilderResourceCollectionRoute + "/{builderName}";
        public const string BuildAgentPoolResourceCollectionRoute = DefaultBuildServiceResourceRoute + "/" + ArmBuildServiceAgentPoolResourceType;
        public const string BuildAgentPoolResourceRoute = BuildAgentPoolResourceCollectionRoute + "/" + "{agentPoolName}";
        public const string BuildResourceCollectionRoute = DefaultBuildServiceResourceRoute + "/" + ArmBuildServiceBuildResourceType;
        public const string BuildResourceRoute = BuildResourceCollectionRoute + "/{buildName}";
        public const string BuildResultResourceCollectionRoute = BuildResourceRoute + "/" + ArmBuildServiceBuildResultResourceType;
        public const string BuildResultResourceRoute = BuildResultResourceCollectionRoute + "/{buildResultName}";
        public const string BuildResultLogResourceRoute = BuildResultResourceRoute + "/getLogFileUrl";
        public const string BuildpacksBindingResourceRoute = DefaultBuildServiceResourceRoute +
            "/" + ArmBuildServiceBuildpacksBindingResourceType + "/" + "{bindingName}";
        public const string BuilderBuildpackBindingResourceRoute = BuilderResourceRoute +
            "/" + ArmBuildServiceBuildpacksBindingResourceType + "/" + "{bindingName}";
        public const string BuildpacksBindingResourceCollectionRoute = DefaultBuildServiceResourceRoute + "/" + ArmBuildServiceBuildpacksBindingResourceType;
        public const string BuilderBuildpackBindingResourceCollectionRoute = BuilderResourceRoute + "/" + "buildpackBindings";
        private const string DefaultBuildServiceResourceRoute = ArmServiceResourcesRoute + "/" + ArmBuildServiceResourceType + "/" + ArmBuildServiceDefaultResourceName;

        public const string ConfigurationServiceResourceCollectionRoute = ArmServiceResourcesRoute + "/" + ArmAcsResourceType;
        public const string ConfigurationServiceResourceRoute = ConfigurationServiceResourceCollectionRoute +
            "/" + "{configurationServiceName}";
        public const string ConfigurationServiceValidateRoute = ConfigurationServiceResourceRoute + "/validate";

        public const string ServiceRegistryResourceCollectionRoute = ArmServiceResourcesRoute + "/" + ArmServiceRegistryResourceType;
        public const string ServiceRegistryResourceRoute = ServiceRegistryResourceCollectionRoute +
            "/" + "{serviceRegistryName}";

        public const string GatewayResourceCollectionRoute = ArmServiceResourcesRoute + "/" + ArmGatewayResourceType;
        public const string GatewayResourceRoute = GatewayResourceCollectionRoute + "/" + "{gatewayName}";
        public const string ScgRouteConfigResourceCollectionRoute = GatewayResourceRoute + "/" + ArmScgRouteConfigResourceType;
        public const string ScgRouteConfigRoute = GatewayResourceRoute + "/" + ArmScgRouteConfigResourceType +
            "/" + "{routeConfigName}";
        public const string ScgCustomDomainResourceCollectionRoute = GatewayResourceRoute + "/" + ArmScgCustomDomainResourceType;
        public const string ScgCustomDomainResourceRoute = GatewayResourceRoute + "/" + ArmScgCustomDomainResourceType +
            "/{domainName}";
        public const string ScgCustomDomainValidateRoute = GatewayResourceRoute + "/validateDomain";

        public const string ApiPortalResourceCollectionRoute = ArmServiceResourcesRoute + "/" + ArmApiPortalResourceType;
        public const string ApiPortalResourceRoute = ApiPortalResourceCollectionRoute + "/" + "{apiPortalName}";
        public const string ApiPortalCustomDomainResourceCollectionRoute = ApiPortalResourceRoute + "/" + ArmApiPortalCustomDomainResourceType;
        public const string ApiPortalCustomDomainResourceRoute = ApiPortalResourceRoute + "/" + ArmApiPortalCustomDomainResourceType +
            "/{domainName}";
        public const string ApiPortalCustomDomainValidateRoute = ApiPortalResourceRoute + "/validateDomain";

        // Resource Group operations
        public const string ResourceGroupPath = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}";
        public const string MoveResourcePath = "moveResources";
        public const string ValidateMoveResourcePath = "validateMoveResources";

        // Check name availability
        public const string CheckNameAvailabilityPath = "/subscriptions/{subscriptionId}/providers/" + ArmNamespace +
                                                        "/locations/{location}/checkNameAvailability";

        // Available runtime versions
        public const string AvailableRuntimeVersionsPath = "/providers/" + ArmServiceFullResourceType + "/runtimeVersions";

        // Available operations
        public const string AvailableOperationsPath = "/providers/" + ArmNamespace + "/operations";

        // Async operation routes
        public const string OperationResultResourceType = "operationResults";

        public const string AsyncOpResultPath = "subscriptions/{subscriptionId}/providers/" + ArmNamespace +
                                                "/locations/{location}/" + OperationResultResourceType +
                                                "/{operationId}";

        public const string AsyncResourceOpResultPath = "subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/" + ArmNamespace +
                                    "/locations/{location}/" + OperationResultResourceType + "/{operationId}/" + ArmServiceResourceType + "/{resourceName}";

        public const string AsyncSubscriptionOpResultPath = "subscriptions/{subscriptionId}/providers/" + ArmNamespace + "/" + OperationResultResourceType + "/{operationId}";

        public const string AsyncProviderOpResultPath = "providers/" + ArmNamespace + "/" + OperationResultResourceType + "/{operationId}";

        public const string OperationStatusResourceType = "operationStatus";
        public const string AsyncOpStatusPath = "subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/" + ArmNamespace +
                                                "/locations/{location}/" + OperationStatusResourceType +
                                                "/{resourceName}/operationId/{operationId}";

        // Container Health Probes
        public const string ReadinessProbePath = "/internal/health";
        public const string LivelinessProbePath = "/internal/liveness";
        public const string KubernetesProbeBase = "http://*:9080";

        public static string BuildAsyncOpStatusPath(string subscriptionId, string resourceGroup, string location,
            string resourceName, string operationId)
        {
            return $"subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/" + ArmNamespace +
                $"/locations/{location}/" + OperationStatusResourceType +
                $"/{resourceName}/operationId/{operationId}";
        }

        public const string SubscriptionAsyncOpStatusPath =
            "subscriptions/{subscriptionId}/providers/" + ArmNamespace + "/" + OperationStatusResourceType +
            "/{operationId}";

        public static string BuildSubscriptionAsyncOpStatusPath(string subscriptionId, string operationId)
        {
            return $"subscriptions/{subscriptionId}/providers/" + ArmNamespace + "/" + OperationStatusResourceType +
                   $"/{operationId}";
        }

        public const string ProviderAsyncOperationStatusPath =
            "providers/" + ArmNamespace + "/" + OperationStatusResourceType + "/{operationId}";

        public static string BuildProviderAsyncOperationStatusPath(string operationId)
        {
            return "providers/" + ArmNamespace + "/" + OperationStatusResourceType + $"/{operationId}";
        }

        public const string SkuPath = "subscriptions/{subscriptionId}/providers/" + ArmNamespace + "/skus";
    }
}
