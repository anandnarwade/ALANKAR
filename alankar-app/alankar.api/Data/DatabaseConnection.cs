using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace alankar.api.Data
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private readonly string _connectionString;

        public DatabaseConnection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ALANKAR-APP-CONNECTION");
        }

        public async Task<T> ExecuteQueryAsync<T>(string query, object parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<T>(query, parameters);
            }
        }

        public async Task<IEnumerable<T>> ExecuteQueryListAsync<T>(string query, object parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<T>(query, parameters);
            }
        }

        public async Task<int> ExecuteNonQueryAsync(string query, object parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
