
using System.Globalization;
using Newtonsoft.Json;

namespace HackerNewsAPI.Entities
{
    public class Story
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string PostedBy { get; set; }
        public long Time { get; set; }

        // Use a helper property to convert Time to DateTime
        [JsonIgnore]
        public DateTime DateTime => DateTimeOffset.FromUnixTimeSeconds(Time).DateTime;

        public int Score { get; set; }
        public int CommentCount { get; set; }
    }
}
