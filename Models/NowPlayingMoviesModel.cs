using System;
namespace MovieApi.Models
{
    public class NowPlayingMoviesModel
    {
        public List<NowPlayingMoviesProp> results { get; set; }
    }
    public class NowPlayingMoviesProp
    {
        public int id { get; set; }
        public string poster_path { get; set; }
        public string title { get; set; }
        public double vote_average { get; set; }
    }
}

