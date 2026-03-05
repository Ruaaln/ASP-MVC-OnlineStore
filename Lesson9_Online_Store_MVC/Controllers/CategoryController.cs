using Microsoft.AspNetCore.Mvc;
using Lesson9_Online_Store_DataAccess.Repositories.Abstracts;
using System.Threading.Tasks;
using Lesson9_Online_Store_Domain.Entities.Concretes;
using Lesson9_Online_Store_Services.Abstractions;

namespace Lesson9_Online_Store_MVC.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategory()
    {
        var result = await _categoryService.GetAllAsync();
        return View(result.Data ?? new List<Category>());
    }

    [HttpGet]
    public IActionResult AddCategory() => View();

    [HttpPost]
    public async Task<IActionResult> AddCategory(Category category)
    {
        var result = await _categoryService.CreateAsync(category);

        if (!result.IsSuccess)
        {
            foreach (var err in result.Errors)
                ModelState.AddModelError(string.Empty, err);

            return View(category);
        }

        return RedirectToAction(nameof(GetAllCategory));
    }
}
