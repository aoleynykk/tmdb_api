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
    
    public class WatchListController : ControllerBase
    {
        private readonly IDynamoDBClient _dynamoDBClient;

        public WatchListController(IDynamoDBClient dynamoDBClient)
        {
            _dynamoDBClient = dynamoDBClient;
        }

        [HttpDelete("DeleteMovieFromWatchList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFromWatchList(int id)
        {
            try
            {
                await _dynamoDBClient.DeleteFromWatchList(id);
                return Ok("SUCCESFULLY REMOVED");
            }
            catch
            {
                return NotFound("NO SUCH FILM");
            }
            

        }

        [HttpGet("GetWatchList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWatchList()
        {
            try
            {
                var response = await _dynamoDBClient.GetWatchList();
                if (response == null)
                    return NotFound("NO DATA");

                var result = response.Select(o => new WatchListResponse()
                {
                    id = o.id,
                    title = o.title,
                    poster_path = o.poster_path,
                    vote_average = o.vote_average
                }).ToList();
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Server Error" + e);
                return StatusCode(500);
            }

           
        }

        [HttpPost("AddToWatchList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddToWatchList([FromBody] WatchListResponse watchListResponse)
        {
            var data = new WatchListResponse
            {
                id = watchListResponse.id,
                title = watchListResponse.title,
                poster_path = watchListResponse.poster_path,
                vote_average = watchListResponse.vote_average
            };

            await _dynamoDBClient.AddMovieToWatchList(data);

            return Ok("SUCCESFFULLY ADDED");
        }

    }
}

