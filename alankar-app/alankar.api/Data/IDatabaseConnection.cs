using System.Collections.Generic;
using System.Threading.Tasks;

namespace alankar.api.Data
{
    public interface IDatabaseConnection
    {
        Task<T> ExecuteQueryAsync<T>(string query, object parameters = null); // For single entity
        Task<IEnumerable<T>> ExecuteQueryListAsync<T>(string query, object parameters = null); // For list of entities
        Task<int> ExecuteNonQueryAsync(string query, object parameters = null);
    }
}
