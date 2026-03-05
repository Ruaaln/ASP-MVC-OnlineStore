using FluentValidation;
using Lesson9_Online_Store_Services.Results;
using Lesson9_Online_Store_Services.Abstractions;
using Lesson9_Online_Store_Domain.Entities.Concretes;
using Lesson9_Online_Store_DataAccess.Repositories.Abstracts;

namespace Lesson9_Online_Store_Services.Concretes;

public sealed class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IValidator<Category> _categoryValidator;

    public CategoryService(ICategoryRepository categoryRepository, IValidator<Category> categoryValidator)
    {
        _categoryRepository = categoryRepository;
        _categoryValidator = categoryValidator;
    }

    public async Task<ServiceResult<List<Category>>> GetAllAsync()
    {
        var data = await _categoryRepository.GetAllAsync();
        return ServiceResult<List<Category>>.Success(data);
    }

    public async Task<ServiceResult<bool>> CreateAsync(Category category)
    {
        category.Products ??= new List<Product>();

        var validation = await _categoryValidator.ValidateAsync(category);
        if (!validation.IsValid)
            return ServiceResult<bool>.Fail(validation.Errors.Select(e => e.ErrorMessage));

        var all = await _categoryRepository.GetAllAsync();
        var isDuplicate = all.Any(c =>
            c.Id != category.Id &&
            (c.Name ?? "").Trim().ToLower() == (category.Name ?? "").Trim().ToLower());

        if (isDuplicate)
            return ServiceResult<bool>.Fail(new[] { "Bu category artıq mövcuddur" });

        await _categoryRepository.AddAsync(category);
        return ServiceResult<bool>.Success(true);
    }
}