using NSubstitute;
using SoftplanTest.Api2.Infrastructure.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace SoftplanTest.Api2.Test
{
    public class Testes
    {
        [Fact]
        public void CalculaJuros_Retorna_Decimal()
        {
            var httpClientFactoryMock = Substitute.For<IHttpClientFactory>();

            var calculaJurosService = new CalculaJurosService(httpClientFactoryMock);

            var valorInicial = 100.00m;
            var tempo = 5;

            Assert.IsType<Task<decimal>>(calculaJurosService.CalculaJurosAsync(valorInicial, tempo));
        }

        [Fact]
        public void ValorInicial_Menor_Que_Zero()
        {
            var httpClientFactoryMock = Substitute.For<IHttpClientFactory>();

            var calculaJurosService = new CalculaJurosService(httpClientFactoryMock);

            var valorInicial = -100.00m;
            var tempo = 5;

            Assert.ThrowsAsync<Exception>(() => calculaJurosService.CalculaJurosAsync(valorInicial, tempo));
        }

        [Fact]
        public void Tempo_Menor_Que_Zero()
        {
            var httpClientFactoryMock = Substitute.For<IHttpClientFactory>();

            var calculaJurosService = new CalculaJurosService(httpClientFactoryMock);

            var valorInicial = 100.00m;
            var tempo = -5;

            Assert.ThrowsAsync<Exception>(() => calculaJurosService.CalculaJurosAsync(valorInicial, tempo));
        }
    }
}
