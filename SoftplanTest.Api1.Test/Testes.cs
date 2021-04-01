using SoftplanTest.Api1.Infrastructure.Repositories;
using SoftplanTest.Api1.Infrastructure.Services;
using System.Threading.Tasks;
using Xunit;

namespace SoftplanTest.Api1.Test
{
    public class Testes
    {
        [Fact]
        public void GetTaxaJuros_RetornaDecimal()
        {
            var taxaJurosService = new TaxaJurosService(new TaxaJurosRepository());

            Assert.IsType<Task<decimal>>(taxaJurosService.GetTaxaJuros());
        }

        [Fact]
        public void GetTaxaJuros_E_Igual_1Porcento()
        {
            var taxaJurosService = new TaxaJurosService(new TaxaJurosRepository());

            decimal valor = 0.01m;

            Assert.Equal(taxaJurosService.GetTaxaJuros().Result, valor);
        }
    }
}
