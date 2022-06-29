using System;
namespace MovieApi.Models
{
	public class MovieVideoModel
	{
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public int id { get; set; }
        public List<MovieVideoProp> results { get; set; }
    }
    public class MovieVideoProp
    {
        public string key { get; set; }
        public string type { get; set; }
        public string id { get; set; }
    }
}

