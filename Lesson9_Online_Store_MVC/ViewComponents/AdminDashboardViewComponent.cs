using Lesson9_Online_Store_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson9_Online_Store_MVC.ViewComponents;

public class AdminDashboardViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var dashBoardGetAll = new List<DashBoardGetAll>()
        {
            new DashBoardGetAll(){Name = "Product", Count = 5, controllerName = "Product", ctionName = "GetAllProduct"},
            new DashBoardGetAll(){Name = "Category", Count = 15, controllerName = "Category", ctionName = "GetAllCategory"}
        };


        return View(dashBoardGetAll);
    }
}
