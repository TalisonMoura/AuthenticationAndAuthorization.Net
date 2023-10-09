using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UsersAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AccessControlController : ControllerBase
    {
        [HttpGet("access")]
        [Authorize(Policy = "Minimum age")]
        public IActionResult Get()
        {
            return Ok("Access allowed!");
        }
    }
}
