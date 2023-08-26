using LibraryManagerApiTests.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace LibraryManagerApiTests
{
    public class Validator
    {
        public static void AssertBookEntities(List<Book> books, string param = "")
        {
            foreach (var book in books)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(string.IsNullOrEmpty(book.Title), Is.False, $"{books.IndexOf(book)} book title is null or empty!");
                    Assert.That(string.IsNullOrEmpty(book.Description), Is.False, $"{books.IndexOf(book)} book description is null or empty!");
                    Assert.That(string.IsNullOrEmpty(book.Author), Is.False, $"{books.IndexOf(book)} book author is null or empty!");

                    Assert.That(book.Title.Contains(param), "Filtering is not correct!");
                });
            }
        }

        public static void AssertBookEntities(Book book)
        {
            Assert.Multiple(() =>
            {
                Assert.That(string.IsNullOrEmpty(book.Title), Is.False, $"Book title is null or empty!");
                Assert.That(string.IsNullOrEmpty(book.Description), Is.False, $"Book description is null or empty!");
                Assert.That(string.IsNullOrEmpty(book.Author), Is.False, $"Book author is null or empty!");
            });
        }

        public static void AssertBookEntity(Book expected, Book actual)
        {
            Assert.Multiple(() =>
            {
                Assert.That(actual.Id, Is.EqualTo(expected.Id));
                Assert.That(actual.Title, Is.EqualTo(expected.Title)); ;
                Assert.That(actual.Description, Is.EqualTo(expected.Description));
                Assert.That(actual.Author, Is.EqualTo(expected.Author));
            });
        }
    }
}
