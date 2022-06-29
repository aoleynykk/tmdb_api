using System;
using MovieApi.Models;
using Newtonsoft.Json;

namespace MovieApi.Clients
{
    public class MovieClient : IMovieClient
    {
        private HttpClient _client;
        private static string _URL;
        private static string _apiKey;
        
        public MovieClient()
        {
            _URL = Constants.URL;
            _apiKey = Constants.apiKey;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_URL) ?? throw new ArgumentNullException(nameof(_client)); ;

        }

        public async Task<TrendingMoviesModel> GetTrendingMovies()
        {
            var responce = await _client.GetAsync($"/3/trending/movie/week?api_key={_apiKey}&language={Constants.lang}");

            responce.EnsureSuccessStatusCode();

            var content = responce.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<TrendingMoviesModel>(content);
            
            return result;
        }

        public async Task<MovieInfoModel> GetMovieInfo(int movieId)
        {
            var responce = await _client.GetAsync($"/3/movie/{movieId}?api_key=ab04cd0db471f8aec7ec3b6be80f900c&language={Constants.lang}");

            responce.EnsureSuccessStatusCode();

            var content = responce.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<MovieInfoModel>(content);

            return result;
        }

        public async Task<MovieSearchModel> GetMovie(string nameOfMovie)
        {
            var responce = await _client.GetAsync($"/3/search/movie?api_key={_apiKey}&language={Constants.lang}&query={nameOfMovie}&page=1&include_adult=false");

            responce.EnsureSuccessStatusCode();

            var content = responce.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<MovieSearchModel>(content);

            return result;
        }

        public async Task<UpcomingMoviesModel> GetUpcomingMovies()
        {
            var responce = await _client.GetAsync($"/3/movie/popular?api_key={_apiKey}&language={Constants.lang}&page=2");

            responce.EnsureSuccessStatusCode();

            var content = responce.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<UpcomingMoviesModel>(content);

            return result;
        }

        public async Task<NowPlayingMoviesModel> GetNowPlayingMovies()
        {
            var responce = await _client.GetAsync($"/3/movie/now_playing?api_key={_apiKey}&language={Constants.lang}&page=1");

            responce.EnsureSuccessStatusCode();

            var content = responce.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<NowPlayingMoviesModel>(content);

            return result;
        }

        public async Task<MovieVideoModel> GetMovieVideo(int movieId)
        {
            var responce = await _client.GetAsync($"/3/movie/{movieId}/videos?api_key={_apiKey}&language={Constants.lang}");

            responce.EnsureSuccessStatusCode();

            var content = responce.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<MovieVideoModel>(content);

            return result;
        }

    }
}
