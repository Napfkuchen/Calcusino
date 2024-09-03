using Calcusino.src.Backend.Models;
using Calcusino.src.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Calcusino.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("create user only with username")]
        public ActionResult<UserModel> CreateUser(string userName)
        {
            var user = _userService.CreateUser(userName);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("create user complete")]
        public ActionResult<UserModel> CreateUser(string userName, string password, string email, string firstName, string lastName)
        {
            var user = _userService.CreateUser(userName, password, email, firstName, lastName);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}