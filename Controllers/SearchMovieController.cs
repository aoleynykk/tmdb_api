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
    public class SearchMovieController : ControllerBase
    {
        [HttpGet("Search")]
        public MovieSearchModel FoundMovie(string nameOfMovie)
        {
            var movieClient = new MovieClient();
            var result = movieClient.GetMovie(nameOfMovie).Result;
            return result;
        }
    }
}

