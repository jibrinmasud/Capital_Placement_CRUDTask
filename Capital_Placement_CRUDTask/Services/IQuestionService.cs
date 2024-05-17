using Capital_Placement_CRUDTask.Models;

namespace Capital_Placement_CRUDTask.Services
{
    public interface IQuestionService
    {
        Task<List<Questions>> Get(string sqlQuery);

        Task<Questions> Add(Questions questions);

        Task<Questions> UpDate(Questions questions);
    }
}