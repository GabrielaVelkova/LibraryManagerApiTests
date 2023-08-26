using LibraryManagerApiTests.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using RestApi;
using RestSharp;
using System.Net;

namespace LibraryManagerApiTests
{
    [TestFixture]
    public class ApiGetTests
    {
        [TestCase("Test", HttpStatusCode.OK)]
        public void GetAllBooksTitleContainsTest(string param, HttpStatusCode expectedHttpStatusCode)
        {
            RestSession restSession = new RestSession($"{ConstantsApiTests.baseUrl}/books?title={param}", Method.Get);

            var response = restSession.Execute();
            var getBooksContent = JsonConvert.DeserializeObject<List<Book>>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));

            Validator.AssertBookEntities(getBooksContent, param);
        }

        [TestCase(1, HttpStatusCode.OK)]
        [TestCase(2, HttpStatusCode.OK)]
        public void GetBooksWithId(int id, HttpStatusCode expectedHttpStatusCode)
        {
            RestSession restSession = new RestSession($"{ConstantsApiTests.baseUrl}/books/{id}", Method.Get);

            var response = restSession.Execute();
            var getBooksContent = JsonConvert.DeserializeObject<Book>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
            Validator.AssertBookEntities(getBooksContent);
        }

        [TestCase(0, HttpStatusCode.NotFound)]
        [TestCase(100, HttpStatusCode.NotFound)]
        public void GetBookIncorrectId(int id, HttpStatusCode expectedStatusCode)
        {
            RestSession restSession = new RestSession($"{ConstantsApiTests.baseUrl}/books/{id}", Method.Get);
            var response = restSession.Execute();

            Assert.That(response.StatusCode, Is.EqualTo(expectedStatusCode));
            Assert.That(response.Content, Does.Contain($"Book with id {id} not found!"));
        }
    }
}