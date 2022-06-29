using System;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using MovieApi.Extensions;
using MovieApi.Models;

namespace MovieApi.Clients
{
    public class DynamoDBClient : IDynamoDBClient, IDisposable
    {
        public string _tableName;
        private readonly IAmazonDynamoDB _dynamoDb;

        public DynamoDBClient(IAmazonDynamoDB dynamoDb)
        {
            _dynamoDb = dynamoDb;
            _tableName = Constants.tableName;
        }

        public void Dispose()
        {
            _dynamoDb.Dispose();
        }

        public async Task<bool> AddMovieToWatchList(WatchListResponse watchListResponse)
        {
            var request = new PutItemRequest
            {
                TableName = _tableName,
                Item = new Dictionary<string, AttributeValue>
                {
                    { "id", new AttributeValue { N = $"{watchListResponse.id}" } },
                    { "title", new AttributeValue { S = watchListResponse.title } },
                    { "poster_path", new AttributeValue { S = watchListResponse.poster_path } },
                    { "vote_average", new AttributeValue { N = $"{watchListResponse.vote_average}" } }
                }
            };

            try
            {
                var response = await _dynamoDb.PutItemAsync(request);
                return response.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch(Exception error)
            {
                Console.WriteLine(error);
                return false;
            }
           
        }

        public async Task DeleteFromWatchList(int id)
        {
            var request = new DeleteItemRequest
            {
                TableName = _tableName,
                Key = new Dictionary<string, AttributeValue>
                {
                    { "id", new AttributeValue { N = $"{id}" } }
                }
            };

            var response = await _dynamoDb.DeleteItemAsync(request);
        }

       

        public async Task<List<WatchListResponse>> GetWatchList()
        {
            var result = new List<WatchListResponse>();

            var request = new ScanRequest
            {
                TableName = _tableName
            };

            var response = await _dynamoDb.ScanAsync(request);

            if (response.Items == null || response.Count == 0)
                return null;

            foreach(Dictionary<string,AttributeValue> item in response.Items)
            {
                result.Add(item.ToClass<WatchListResponse>());
            }
            return result;

        }
    }
}

