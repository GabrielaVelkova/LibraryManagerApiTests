using RestApi.Configuration;
using RestSharp;

namespace RestApi
{
    public class RestClientFactory : IRestClientFactory
    {
        private readonly IApiBaseSection config;

        public RestClientFactory(IApiBaseSection config)
        {
            this.config = config;
        }

        public IRestClient Create()
        {
            var restClient = new RestClient(config.BaseUrl);
            if (config.Headers != null)
            {
                restClient.AddDefaultHeaders(new Dictionary<string, string>(config.Headers));
            }

            return restClient;
        }
    }
}