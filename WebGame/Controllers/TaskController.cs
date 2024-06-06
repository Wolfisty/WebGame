using Microsoft.AspNetCore.Mvc;

namespace WebGame.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
