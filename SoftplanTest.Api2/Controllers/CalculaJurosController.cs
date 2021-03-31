using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SoftplanTest.Api2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ILogger<CalculaJurosController> _logger;

        public CalculaJurosController(ILogger<CalculaJurosController> logger)
        {
            _logger = logger;
        }
    }
}
