using RestSharp;

namespace RestApi
{
    public interface IRestClientFactory
    {
        IRestClient Create();
    }
}
