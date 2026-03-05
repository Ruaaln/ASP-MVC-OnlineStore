using FluentValidation;
using Lesson9_Online_Store_Domain.Entities.Concretes;

namespace Lesson9_Online_Store_DataAccess.Validations.CategoryValidation;

public sealed class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator() 
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category adı boş ola bilməz")
            .MinimumLength(2).WithMessage("Category adı minimum 2 simvol olmalıdır")
            .MaximumLength(16).WithMessage("Category adı maksimum 16 simvol olmalıdır");
    }
}