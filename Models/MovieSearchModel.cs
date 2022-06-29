using System;
namespace MovieApi.Models
{
	public class MovieSearchModel
	{
        public List<MovieProp> results { get; set; }
    }
    public class MovieProp
    {
        public int id { get; set; }
        public string poster_path { get; set; }
        public string title { get; set; }
        public double vote_average { get; set; }
    }
}

