using Microsoft.AspNetCore.Mvc;

namespace UrbanaThreadsProject.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Home/Data.cshtml"); // Analytics page
        }
    }
}
