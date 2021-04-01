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
            try
            {
                if (valorInicial >= 0 && tempo >= 0)
                {
                    var taxaJuros = await GetTaxaJurosApi();

                    var valorFinal = valorInicial * Convert.ToDecimal(Math.Pow((Convert.ToDouble(1 + taxaJuros)), tempo));

                    return Math.Truncate(100 * valorFinal) / 100;
                }
                else
                {
                    throw new Exception("Os parâmetros valorInicial e tempo devem ser maiores ou iguais a zero");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<decimal> GetTaxaJurosApi()
        {
            try
            {
                var client = _clientFactory.CreateClient();
                client.BaseAddress = new Uri("http://localhost:5001");

                var response = await client.GetAsync($"taxaJuros");

                if (response.IsSuccessStatusCode)
                {
                    var resultado = await response.Content.ReadAsStringAsync();

                    var taxaJuros = JsonConvert.DeserializeObject<decimal>(resultado);

                    return taxaJuros;
                }
                else
                {
                    throw new Exception("Erro ao acessar API");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
