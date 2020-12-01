using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using poc_push_notification.domain.Model;
using poc_push_notification.service.Interface;

namespace poc_push_notification.api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateRequest model)
        {
            var response = _service.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _service.GetAll();
            return Ok(users);
        }
    }
}
