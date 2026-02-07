using Microsoft.AspNetCore.Mvc;
using Lesson9_Online_Store_DataAccess.Repositories.Abstracts;
using System.Threading.Tasks;
using Lesson9_Online_Store_Domain.Entities.Concretes;

namespace Lesson9_Online_Store_MVC.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategory() => View(await _categoryRepository.GetAllAsync());

    [HttpGet]
    public IActionResult AddCategory() => View();

    [HttpPost]
    public async Task<IActionResult> AddCategory(Category category)
    {
        category.Products = new List<Product>();
        if (!ModelState.IsValid)
            return View();

        await _categoryRepository.AddAsync(category);
        return RedirectToAction("GetAllCategory");
    }

}
