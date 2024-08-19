using Boren.Traveler.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Boren.Traveler.Web.Controllers
{
    //[Authorize]
    public class TripController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
