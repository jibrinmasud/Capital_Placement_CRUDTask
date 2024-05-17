using Capital_Placement_CRUDTask.Models;
using Capital_Placement_CRUDTask.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capital_Placement_CRUDTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sqlQuery = "Select * from c";
            var result = await _questionService.Get(sqlQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Questions questions)
        {
            questions.id = Guid.NewGuid().ToString();
            var result = await _questionService.Add(questions);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Questions questions)
        {
            var results = await _questionService.UpDate(questions);
            return Ok(results);
        }
    }
}