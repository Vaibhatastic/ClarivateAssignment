using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClarivateAssessment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(GetUserName());
        }

        private string GetUserName()
        {
            string[] userNames = new string[] { "John", "Jane", "Doe", "Smith", "vick", "Michael" };
            Random random = new Random();
            return userNames[random.Next(0, userNames.Length)];

        }
    }
}
