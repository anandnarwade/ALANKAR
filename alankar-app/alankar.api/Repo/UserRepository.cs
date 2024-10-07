using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using alankar.api.Models;
using Microsoft.AspNetCore.Identity;

namespace alankar.api.Repo
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ALANKAR-APP-CONNECTION");
        }
        public async Task<int> CreateUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Users (Username, PasswordHash, Email, IsActive) " +
                            "VALUES (@Username, @PasswordHash, @Email, @IsActive); " +
                            "SELECT CAST(SCOPE_IDENTITY() as int)";
                return await connection.QuerySingleAsync<int>(query, user);
            }
        }

        public async Task DeleteUser(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Users WHERE UserID = @UserID";
                await connection.ExecuteAsync(query, new { UserID = userId });
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Users";
                return await connection.QueryAsync<User>(query);
            }
        }

        public async Task<User> GetUserById(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Users WHERE UserID = @UserID";
                return await connection.QueryFirstOrDefaultAsync<User>(query, new { UserID = userId });
            }
        }

        public async Task UpdateUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Users SET Username = @Username, PasswordHash = @PasswordHash, " +
                            "Email = @Email, IsActive = @IsActive WHERE UserID = @UserID";
                await connection.ExecuteAsync(query, user);
            }
        }
    }
}
