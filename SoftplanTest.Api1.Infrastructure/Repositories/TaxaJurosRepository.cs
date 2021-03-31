using Dapper;
using SoftplanTest.Api1.Domain.Interfaces;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SoftplanTest.Api1.Infrastructure.Repositories
{
    public class TaxaJurosRepository : ITaxaJurosRepository
    {
        public async Task<decimal> GetTaxaJuros()
        {
            //var strConexao = ConfigurationManager.AppSettings["conexaoBancoDados"];

            //using (var conexaoBD = new SqlConnection(strConexao))
            //{
            //    var taxaJuros = await conexaoBD.QueryFirstOrDefault("SELECT taxa_juros from Taxa");

                var taxaJuros = 0.01m;

            return taxaJuros;
            //}
        }
    }
}
