using Moq;
using NUnit.Framework;
using RestApi;
using RestApi.Configuration;

namespace UnitTests
{
    public class RestFactoryTests
    {
        [Test]
        public void IsCreateSuccessful()
        {
            var configuration = new Mock<IApiBaseSection>();
            var restClientFactory = new RestClientFactory(configuration.Object);
            var restClient = restClientFactory.Create();

            Assert.IsNotNull(restClient);
        }
    }
}