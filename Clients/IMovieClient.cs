using System;
using MovieApi.Models;

namespace MovieApi.Clients
{
	public interface IMovieClient
	{
		Task<TrendingMoviesModel> GetTrendingMovies(); //
		Task<MovieInfoModel> GetMovieInfo(int movieId);
		Task<MovieSearchModel> GetMovie(string nameOfMovie);
		Task<UpcomingMoviesModel> GetUpcomingMovies();
		Task<NowPlayingMoviesModel> GetNowPlayingMovies();
		Task<MovieVideoModel> GetMovieVideo(int movieId);
    }
}

