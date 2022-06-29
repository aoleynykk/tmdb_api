using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Clients;
using MovieApi.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieApi.Controllers
{
    [ApiController]
    public class MovieListOf : ControllerBase
    {
        [HttpGet("UpcomingMovies")]
        public UpcomingMoviesModel UpcomingMovies()
        {
            var movieClient = new MovieClient();
            var result = movieClient.GetUpcomingMovies().Result;
            return result;
        }

        [HttpGet("NowPlayingMovies")]
        public NowPlayingMoviesModel NowPlayingMovies()
        {
            var movieClient = new MovieClient();
            var result = movieClient.GetNowPlayingMovies().Result;
            return result;
        }
        [HttpGet("TrendingMovies")]
        public TrendingMoviesModel TrendingMovies()
        {
            var movieClient = new MovieClient();
            var result = movieClient.GetTrendingMovies().Result;
            return result;
        }
    }
}

