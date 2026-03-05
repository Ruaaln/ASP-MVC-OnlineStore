using Lesson9_Online_Store_Services.Results;
using Lesson9_Online_Store_Domain.Entities.Concretes;


namespace Lesson9_Online_Store_Services.Abstractions;

public interface ICategoryService
{
    Task<ServiceResult<List<Category>>> GetAllAsync();
    Task<ServiceResult<bool>> CreateAsync(Category category);
}
