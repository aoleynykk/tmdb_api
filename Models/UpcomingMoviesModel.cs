using System;
namespace MovieApi.Models
{
    public class UpcomingMoviesModel
    {
        public List<UpcomingMoviesProp> results { get; set; }
    }
    public class UpcomingMoviesProp
    {
        public int id { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public string title { get; set; }
        public double vote_average { get; set; }
    }
}

