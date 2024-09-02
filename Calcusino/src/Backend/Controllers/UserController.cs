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

        [HttpPost("create")]
        public ActionResult<UserModel> CreateUser(string userName)
        {
            var user = _userService.CreateUser(userName);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
