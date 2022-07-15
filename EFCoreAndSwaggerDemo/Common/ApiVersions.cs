namespace EFCoreAndSwaggerDemo.Common
{
    public static class ApiVersions
    {
        /// <summary>
        ///     The query parameter for the API version.
        /// </summary>
        public const string ApiVersionQueryKey = "api-version";

        #region Supported Versions
        public const string v1 = "v1";
        public const string v2 = "v2";
        #endregion

        public static readonly IList<string> All = new List<string>()
        {
            v1,
            v2
        };

        public static string GetLatestVersion()
        {
            return All.Max();
        }
    }
}
