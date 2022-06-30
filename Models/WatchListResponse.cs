using System;
namespace MovieApi.Models
{
	public class WatchListResponse
	{
		public int id { get; set; }
        public string title { get; set; }
		public string poster_path { get; set; }
		public int vote_average { get; set; }
		public string overview { get; set; }
    }
}

