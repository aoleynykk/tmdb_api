using System;
using MovieApi.Models;

namespace MovieApi.Clients
{
	public interface IDynamoDBClient
	{
		public Task<bool> AddMovieToWatchList(WatchListResponse watchListResponse);
		public Task DeleteFromWatchList(int id);
		public Task<List<WatchListResponse>> GetWatchList();
	}
}

