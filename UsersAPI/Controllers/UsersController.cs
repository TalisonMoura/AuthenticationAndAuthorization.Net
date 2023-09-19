using Microsoft.AspNetCore.Mvc;
using UsersAPI.Data.Dtos;

namespace UsersAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateUser(CreateUserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
