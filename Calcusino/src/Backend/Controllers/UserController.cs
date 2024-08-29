using Microsoft.AspNetCore.Mvc;

namespace Calcusino.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public ActionResult<UserModel> GetUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        public ActionResult<UserModel> CreateUser(string userName)
        {
            var user = _userService.CreateUser(userName);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        // Weitere Actions wie CreateUser, UpdateUser, DeleteUser...
    }
}
