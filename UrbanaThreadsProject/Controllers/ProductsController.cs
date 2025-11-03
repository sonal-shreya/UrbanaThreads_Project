using Microsoft.AspNetCore.Mvc;

namespace UrbanaThreadsProject.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Products/read.cshtml"); // default = inventory list
        }

        public IActionResult Create()
        {
            return View("~/Views/Products/create.cshtml");
        }

        public IActionResult Update()
        {
            return View("~/Views/Products/update.cshtml");
        }

        public IActionResult Delete()
        {
            return View("~/Views/Products/delete.cshtml");
        }
    }
}
