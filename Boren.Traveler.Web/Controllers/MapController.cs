using Microsoft.AspNetCore.Mvc;

namespace Boren.Traveler.Web.Controllers
{
    public class MapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
