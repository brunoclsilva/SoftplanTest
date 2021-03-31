using SoftplanTest.Api1.Domain.Interfaces;
using SoftplanTest.Api1.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace SoftplanTest.Api1.Infrastructure.Services
{
    public class TaxaJurosService : ITaxaJurosService
    {
        private readonly ITaxaJurosRepository _taxaJurosRepository;

        public TaxaJurosService(ITaxaJurosRepository taxaJurosRepository)
        {
            _taxaJurosRepository = taxaJurosRepository;
        }

        public async Task<decimal> GetTaxaJuros()
        {
            return await _taxaJurosRepository.GetTaxaJuros();
        }
    }
}
