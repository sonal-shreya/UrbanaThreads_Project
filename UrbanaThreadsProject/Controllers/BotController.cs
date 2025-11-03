using Microsoft.AspNetCore.Mvc;

namespace UrbanaThreadsProject.Controllers
{
    public class BotController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Home/Bot.cshtml");
        }
    }
}
