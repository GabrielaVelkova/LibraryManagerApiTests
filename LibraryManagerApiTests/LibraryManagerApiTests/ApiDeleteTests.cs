using NUnit.Framework;
using RestApi;
using RestSharp;
using System.Net;

namespace LibraryManagerApiTests
{
    [TestFixture]
    public class ApiDeleteTests
    {
        [TestCase(1, HttpStatusCode.NoContent)]
        public void DeleteABook(int id, HttpStatusCode expectedStatusCode)
        {
            RestSession restSession = new RestSession($"{ConstantsApiTests.baseUrl}/books/{id}", Method.Delete);
            var response = restSession.Execute();
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(expectedStatusCode));
                Assert.That(response.Content, Is.EqualTo(string.Empty));
            });
            
        }
    }
}
