using System;
namespace MovieApi.Models
{
    public class TrendingMoviesModel
    {
        public List<TrendMovieProp> results { get; set; }
    }
    public class TrendMovieProp
    {
        public int id { get; set; }
        public double vote_average { get; set; }
        public string poster_path { get; set; }
        public string title { get; set; }
    }
}
