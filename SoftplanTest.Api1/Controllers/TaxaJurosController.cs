using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoftplanTest.Api1.Infrastructure.Interfaces;
using System;

namespace SoftplanTest.Api1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaJurosController : ControllerBase
    {
        private readonly ILogger<TaxaJurosController> _logger;
        private readonly ITaxaJurosService _taxaJurosService;

        public TaxaJurosController(ILogger<TaxaJurosController> logger,
                                   ITaxaJurosService taxaJurosService)
        {
            _logger = logger;
            _taxaJurosService = taxaJurosService;
        }

        [HttpGet]
        [Route("/taxaJuros")]
        public IActionResult GetTaxaJuros()
        {
            try
            {
                _logger.LogInformation("Buscando taxa de juros...");
                var response = _taxaJurosService.GetTaxaJuros();
                _logger.LogInformation("Taxa de juros encontrada!");

                return Ok(response.Result);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error: {e.Message}");
                throw new Exception($"Error: {e.Message}");
            }
        }
    }
}
