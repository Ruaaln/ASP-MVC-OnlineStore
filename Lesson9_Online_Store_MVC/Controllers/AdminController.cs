using Microsoft.AspNetCore.Mvc;

namespace Lesson9_Online_Store_MVC.Controllers;

public class AdminController : Controller
{
    public IActionResult Dashboard()
    {
        return View();
    }
}
