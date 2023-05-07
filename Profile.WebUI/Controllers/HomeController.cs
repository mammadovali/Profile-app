using Microsoft.AspNetCore.Mvc;

namespace Profile.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
