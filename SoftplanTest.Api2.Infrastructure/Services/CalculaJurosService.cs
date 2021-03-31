using Newtonsoft.Json;
using SoftplanTest.Api2.Infrastructure.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SoftplanTest.Api2.Infrastructure.Services
{
    public class CalculaJurosService: ICalculaJurosService
    {
        private readonly IHttpClientFactory _clientFactory;

        public CalculaJurosService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<decimal> CalculaJurosAsync(decimal valorInicial, int tempo)
        {
            var taxaJuros = await GetTaxaJurosApi();

            var valorFinal = valorInicial * Convert.ToDecimal(Math.Pow((Convert.ToDouble(1 + taxaJuros)), tempo));

            return Math.Truncate(100 * valorFinal) / 100;
        }

        public async Task<decimal> GetTaxaJurosApi()
        {
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri("http://localhost:5001");

            decimal taxaJuros = 0.00m;

            var response = await client.GetAsync($"taxaJuros");

            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();

                var obj = JsonConvert.DeserializeObject<decimal>(resultado);

                taxaJuros = obj;
            }

            return taxaJuros;
        }
    }
}
