using Capital_Placement_CRUDTask.Services;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//injecting the cosmos Db
builder.Services.AddSingleton<IQuestionService>(options =>
{
    string URL = builder.Configuration.GetSection("ConnectionStrings")
    .GetValue<string>("URL");

    string primaryKey = builder.Configuration.GetSection("ConnectionStrings")
    .GetValue<string>("primaryKey");

    string dbName = builder.Configuration.GetSection("ConnectionStrings")
    .GetValue<string>("DatabaseName");

    string containerName = builder.Configuration.GetSection("ConnectionStrings")
    .GetValue<string>("ContainerName");

    var cosmosClient = new CosmosClient(URL, primaryKey);

    return new QuestionService(cosmosClient, dbName, containerName);
});

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