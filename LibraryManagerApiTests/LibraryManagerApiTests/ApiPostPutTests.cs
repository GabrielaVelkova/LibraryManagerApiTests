using LibraryManagerApiTests.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using RestApi;
using RestSharp;
using System.Net;

namespace LibraryManagerApiTests
{
    [TestFixture]
    public class ApiPostPutTests
    {
        [TestCase(10, "Test10", "TestAuthor10", "TestDescription10", HttpStatusCode.OK)]
        public void PostABook(int id, string title, string author, string description, HttpStatusCode expectedStatusCode)
        {
            var bookData = new Book { Id = id, Title = title, Author = author, Description = description };

            RestSession restSession = new RestSession($"{ConstantsApiTests.baseUrl}/books/", Method.Post);
            restSession.Request.AddBody(JsonConvert.SerializeObject(bookData));
            var response = restSession.Execute();

            Assert.That(response.StatusCode, Is.EqualTo(expectedStatusCode));
            var desirializedReponseContent = JsonConvert.DeserializeObject<Book>(response.Content);
            Validator.AssertBookEntity(bookData, desirializedReponseContent);
        }

        [TestCase(1, "Test10", "TestAuthor10", "TestDescription10", HttpStatusCode.BadRequest)]
        public void PostABookExistingId(int id, string title, string author, string description, HttpStatusCode expectedStatusCode)
        {
            var bookData = new Book { Id = id, Title = title, Author = author, Description = description };
            RestSession restSession = new RestSession($"{ConstantsApiTests.baseUrl}/books/", Method.Post);
            restSession.Request.AddBody(JsonConvert.SerializeObject(bookData));

            var response = restSession.Execute();
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(expectedStatusCode));
                Assert.That(response.Content, Does.Contain($"Book with id {id} already exists!"));
            });
        }

        [TestCase(3, "Test30", "TestAuthor30", "TestDescription30", HttpStatusCode.OK)]
        public void UpdateABook(int id, string title, string author, string description, HttpStatusCode expectedStatusCode)
        {
            var bookData = new Book { Id = id, Title = title, Author = author, Description = description };
            RestSession restSession = new RestSession($"{ConstantsApiTests.baseUrl}/books/{id}", Method.Put);
            restSession.Request.AddBody(JsonConvert.SerializeObject(bookData));

            var response = restSession.Execute();

            Assert.That(response.StatusCode, Is.EqualTo(expectedStatusCode));
            var desirializedReponseContent = JsonConvert.DeserializeObject<Book>(response.Content);
            Validator.AssertBookEntity(bookData, desirializedReponseContent);
        }


        [TestCase(100, "Test30", "TestAuthor30", "TestDescription30", HttpStatusCode.NotFound)]
        public void UpdateABookNoExistingId(int id, string title, string author, string description, HttpStatusCode expectedStatusCode)
        {
            var bookData = new Book { Id = id, Title = title, Author = author, Description = description };
            RestSession restSession = new RestSession($"{ConstantsApiTests.baseUrl}/books/{id}", Method.Put);
            restSession.Request.AddBody(JsonConvert.SerializeObject(bookData));

            var response = restSession.Execute();

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(expectedStatusCode));
                Assert.That(response.Content, Does.Contain($"Book with id {id} not found!"));
            });
        }
    }
}
