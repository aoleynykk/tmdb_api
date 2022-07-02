using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using MovieApi.Clients;
using MovieApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var credentials = new BasicAWSCredentials("", "");
var config = new AmazonDynamoDBConfig()
{
    RegionEndpoint = RegionEndpoint.USEast1
};
var client = new AmazonDynamoDBClient(credentials, config);
builder.Services.AddSingleton<IAmazonDynamoDB>(client);
builder.Services.AddSingleton<IDynamoDBContext, DynamoDBContext> ();
builder.Services.AddSingleton<IDynamoDBClient, DynamoDBClient>();

builder.Services.AddScoped<TrendingMoviesModel>();
builder.Services.AddScoped<MovieInfoModel>();
builder.Services.AddScoped<MovieSearchModel>();
builder.Services.AddScoped<UpcomingMoviesModel>();
builder.Services.AddScoped<NowPlayingMoviesModel>();
builder.Services.AddScoped<MovieVideoModel>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

