namespace RestApi.Configuration
{
    public interface IApiBaseSection
    {
        Uri BaseUrl { get; set; }

        BasicAuthenticationSection BasicAuth { get; }

        IDictionary<string, string> Headers { get; }
    }
}