using System.Collections.Generic;
using System.Threading.Tasks;
using alankar.api.Models;

namespace alankar.api.Repo
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int userId);
        Task<int> CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int userId);
    }
}
