using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClarivateAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Service is running");
        }
    }
}
