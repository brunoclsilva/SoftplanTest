using System.Threading.Tasks;

namespace SoftplanTest.Api1.Infrastructure.Interfaces
{
    public interface ITaxaJurosService
    {
        Task<decimal> GetTaxaJuros();
    }
}
