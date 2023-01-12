using Microsoft.AspNetCore.Mvc;

namespace JwtApp.Front.Components
{
    public class NavbarViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
