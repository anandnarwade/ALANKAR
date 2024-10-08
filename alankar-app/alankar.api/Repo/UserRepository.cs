using System.Collections.Generic;
using System.Threading.Tasks;
using alankar.api.Models;
using alankar.api.Data;

namespace alankar.api.Repo
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IDatabaseConnection databaseConnection) : base(databaseConnection)
        {
        }

        public async Task<int> CreateUser(User user)
        {
            var query = "INSERT INTO Users (Username, PasswordHash, Email, IsActive) " +
                        "VALUES (@Username, @PasswordHash, @Email, @IsActive); " +
                        "SELECT CAST(SCOPE_IDENTITY() as int)";
            return await CreateAsync(query, user);
        }

        public async Task DeleteUser(int userId)
        {
            var query = "DELETE FROM Users WHERE UserID = @UserID";
            await DeleteAsync(query, userId);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var query = "SELECT * FROM Users";
            return await GetAllAsync(query);
        }

        public async Task<User> GetUserById(int userId)
        {
            var query = "SELECT * FROM Users WHERE UserID = @UserID";
            return await GetByIdAsync(query, userId);
        }

        public async Task UpdateUser(User user)
        {
            var query = "UPDATE Users SET Username = @Username, PasswordHash = @PasswordHash, " +
                        "Email = @Email, IsActive = @IsActive WHERE UserID = @UserID";
            await UpdateAsync(query, user);
        }
    }
}
