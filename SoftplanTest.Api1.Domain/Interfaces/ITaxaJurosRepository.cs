using System.Threading.Tasks;

namespace SoftplanTest.Api1.Domain.Interfaces
{
    public interface ITaxaJurosRepository
    {
        Task<decimal> GetTaxaJuros();
    }
}
