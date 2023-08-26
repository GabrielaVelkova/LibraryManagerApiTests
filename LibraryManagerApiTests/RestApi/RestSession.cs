using RestSharp;

namespace RestApi
{
    public class RestSession
    {
        public RestSession(string baseUrl, Method method)
        {
            Client = new RestClient(baseUrl);
            Request = new RestRequest(baseUrl, method);
            Response = new RestResponse();
        }

        public IRestClient Client { get; set; }

        public RestRequest Request { get; set; }

        public RestResponse Response { get; set; }

        public RestResponse Execute()
        {
            return Response = Client.ExecuteAsync(Request).Result;
        }
    }
}
