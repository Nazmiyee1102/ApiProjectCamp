using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebUI.ViewComponents
{
    public class _AboutDashboardComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

}
