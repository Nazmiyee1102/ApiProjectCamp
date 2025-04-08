using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
