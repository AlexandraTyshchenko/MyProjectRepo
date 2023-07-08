using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services.UserServices;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService= userService;
        }
        [HttpPost]
        public ActionResult<string> Register([FromBody] UserRegistrationModel userRegistrationModel)
        {
            var result = _userService.Register(userRegistrationModel);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("login")]
        public ActionResult<string> LogIn(UserAuthModel userAuthModel) { 
            
           var result= _userService.LogIn(userAuthModel);
            if (result!=null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
