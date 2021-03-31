using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoftplanTest.Api2.Infrastructure.Interfaces;
using System;

namespace SoftplanTest.Api2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ILogger<CalculaJurosController> _logger;
        private readonly ICalculaJurosService _calculaJurosService;

        public CalculaJurosController(ILogger<CalculaJurosController> logger,
                                      ICalculaJurosService calculaJurosService)
        {
            _logger = logger;
            _calculaJurosService = calculaJurosService;
        }

        [HttpGet]
        [Route("/calculajuros")]
        public IActionResult GetTaxaJuros(decimal valorInicial, int tempo)
        {
            try
            {
                _logger.LogInformation("Calculando taxa de juros...");
                var response = _calculaJurosService.CalculaJurosAsync(valorInicial, tempo).Result;
                _logger.LogInformation("Taxa de juros calculada!");

                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error: {e.Message}");
                throw new Exception($"Error: {e.Message}");
            }
        }

        [HttpGet]
        [Route("/showmethecode")]
        public IActionResult ShowMeTheCode()
        {
            try
            {
                _logger.LogInformation("Calculando taxa de juros...");
                var response = "https://github.com/brunoclsilva/SoftplanTest/tree/master";
                _logger.LogInformation("Taxa de juros calculada!");

                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error: {e.Message}");
                throw new Exception($"Error: {e.Message}");
            }
        }
    }
}
