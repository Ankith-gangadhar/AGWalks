using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGWalks.API.Controllers
{
    //https://localhost:7097/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //https://localhost:7097/api/students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentNames = new string[] { "John", "Jane", "Jack", "Ankith", "Anvi" };

            return Ok(studentNames);
        }
    }
}
