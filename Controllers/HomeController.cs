using Microsoft.AspNetCore.Mvc;

namespace MVCWeek9.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() // Home view
        {
            return View();
        }
    }
}