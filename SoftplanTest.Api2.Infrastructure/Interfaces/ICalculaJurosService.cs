using System.Threading.Tasks;

namespace SoftplanTest.Api2.Infrastructure.Interfaces
{
    public interface ICalculaJurosService
    {
        Task<decimal> CalculaJurosAsync(decimal valorInicial, int tempo);
        Task<decimal> GetTaxaJurosApi();
    }
}
