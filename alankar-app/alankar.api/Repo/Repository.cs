using System.Collections.Generic;
using System.Threading.Tasks;
using alankar.api.Data;

namespace alankar.api.Repo
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDatabaseConnection _databaseConnection;

        public Repository(IDatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public async Task<int> CreateAsync(string query, T entity)
        {
            return await _databaseConnection.ExecuteNonQueryAsync(query, entity);
        }

        public async Task<T> GetByIdAsync(string query, int id)
        {
            return await _databaseConnection.ExecuteQueryAsync<T>(query, new { UserID = id });
        }

        public async Task<IEnumerable<T>> GetAllAsync(string query)
        {
            return await _databaseConnection.ExecuteQueryListAsync<T>(query);
        }

        public async Task UpdateAsync(string query, T entity)
        {
            await _databaseConnection.ExecuteNonQueryAsync(query, entity);
        }

        public async Task DeleteAsync(string query, int id)
        {
            await _databaseConnection.ExecuteNonQueryAsync(query, new { UserID = id });
        }
    }
}
