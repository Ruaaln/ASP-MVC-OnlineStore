using FluentValidation;
using Lesson9_Online_Store_DataAccess.Validations.CategoryValidation;
using Lesson9_Online_Store_DataAccess.Validations.ProductValidation;
using Lesson9_Online_Store_Domain.Entities.Concretes;
using Lesson9_Online_Store_Services.Abstractions;
using Lesson9_Online_Store_Services.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace Lesson9_Online_Store_Services.Extensions;


public static class ServiceRegistration
{
    public static IServiceCollection AddStoreServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();

        services.AddScoped<IValidator<Product>, ProductValidator>();
        services.AddScoped<IValidator<Category>, CategoryValidator>();

        return services;
    }
}