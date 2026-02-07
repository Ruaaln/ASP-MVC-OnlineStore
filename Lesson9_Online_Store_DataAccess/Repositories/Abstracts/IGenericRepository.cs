using Lesson9_Online_Store_Domain.Entities.Abstracts;

namespace Lesson9_Online_Store_DataAccess.Repositories.Abstracts;

public interface IGenericRepository<T> where T: BaseEntity ,new()
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsnyc(int id);
}
