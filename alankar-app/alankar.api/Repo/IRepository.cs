using System.Collections.Generic;
using System.Threading.Tasks;

namespace alankar.api.Repo
{
    public interface IRepository<T>
    {
        Task<int> CreateAsync(string query, T entity);
        Task<T> GetByIdAsync(string query, int id);
        Task<IEnumerable<T>> GetAllAsync(string query);
        Task UpdateAsync(string query, T entity);
        Task DeleteAsync(string query, int id);
    }
}
