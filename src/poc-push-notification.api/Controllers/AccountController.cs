using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using poc_push_notification.api.Helpers;
using poc_push_notification.domain.Model;
using poc_push_notification.service.Interface;

namespace poc_push_notification.api.Controllers
{
    [Authorize]
    [Route("api/v1/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ITokenService _service;

        public AccountController(ITokenService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [Produces("application/json")]
        public IActionResult Post(User user) => Ok(_service.Generate(user));

        [HttpGet]
        [Route("info")]
        [Produces("application/json")]
        [AllowAnonymous]
        public IActionResult GetInfo() {
            var user = AccessHelper.getTokenAttributes(User.Claims);
            return Ok(user);
        }
    }
}
