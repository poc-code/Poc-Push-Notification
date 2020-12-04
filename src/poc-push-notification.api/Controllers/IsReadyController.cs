using Microsoft.AspNetCore.Mvc;

namespace poc_push_notification.api.Controllers
{
    [Route("api/isready")]
    [ApiController]
    public class IsReadyController : ControllerBase
    {
        public IActionResult Get() => Ok(new { 
            Status = "Is Ready",
            Message = "Treino Fácil, guerra difícil. Treino difícil, guerra fácil."
        });
    }
}
