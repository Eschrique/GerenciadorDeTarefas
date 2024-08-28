using Microsoft.AspNetCore.Mvc;
using GerenciadorDeTarefas.Infrastructure.Data;


namespace GerenciadorDeTarefas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Aplicação está funcionando!");
        }
    }
}
