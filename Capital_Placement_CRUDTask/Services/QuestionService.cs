using Capital_Placement_CRUDTask.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Azure.Cosmos;

namespace Capital_Placement_CRUDTask.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly Container _container;

        public QuestionService(CosmosClient client, string databaseName, string containerName)
        {
            _container = client.GetContainer(databaseName, containerName);
        }

        public async Task<Questions> Add(Questions questions)
        {
            var item = await _container.CreateItemAsync(questions, new PartitionKey(questions.questionstype));
            return item;
        }

        public async Task<List<Questions>> Get(string sqlQuery)
        {
            var query = _container.GetItemQueryIterator<Questions>(new QueryDefinition(sqlQuery));
            List<Questions> results = new List<Questions>();
            while (query.HasMoreResults)
            {
                var res = await query.ReadNextAsync();
                results.AddRange(res);
            }
            return results;
        }

        public async Task<Questions> UpDate(Questions questions)
        {
            var item = await _container.UpsertItemAsync<Questions>(questions, new PartitionKey(questions.questionstype));
            return item;
        }
    }
}