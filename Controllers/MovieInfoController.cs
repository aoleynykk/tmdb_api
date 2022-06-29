using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Clients;
using MovieApi.Models;


namespace MovieApi.Controllers
{
    [ApiController]
    public class MovieInfoController : ControllerBase
    {

        [HttpGet("MovieInfo")]
        public MovieInfoModel MovieInfo(int movieId)
        {
            var movieClient = new MovieClient();
            var result = movieClient.GetMovieInfo(movieId).Result; 
            return result;
        }

        [HttpGet("MovieVideo")]
        public MovieVideoModel MovieVideo(int movieId)
        {
            var movieClient = new MovieClient();
            var result = movieClient.GetMovieVideo(movieId).Result;
            return result;
        }

    }
}

