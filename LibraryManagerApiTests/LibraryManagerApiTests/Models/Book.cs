using Newtonsoft.Json;

namespace LibraryManagerApiTests.Models
{
    public class Book
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Author")]
        public string Author { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }
    }
}
