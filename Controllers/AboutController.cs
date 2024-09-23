using Microsoft.AspNetCore.Mvc;

namespace MVCWeek9.Controllers
{
    public class AboutController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

}