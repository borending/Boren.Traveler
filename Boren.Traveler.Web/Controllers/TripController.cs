using Microsoft.AspNetCore.Mvc;

namespace Boren.Traveler.Web.Controllers
{
    public class TripController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
