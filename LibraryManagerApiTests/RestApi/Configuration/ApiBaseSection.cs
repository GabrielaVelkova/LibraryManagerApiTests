namespace RestApi.Configuration
{
    public class ApiBaseSection : IApiBaseSection
    {
        public Uri BaseUrl { get; set; }

        public BasicAuthenticationSection BasicAuth { get; set; }

        public IDictionary<string, string> Headers { get; set; }

    }
}