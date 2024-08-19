using Boren.Traveler.Data;
using Boren.Traveler.Service;
using Boren.Traveler.Web.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Boren.Traveler.Web.Controllers
{
    // references: https://learn.microsoft.com/zh-tw/aspnet/core/web-api/?view=aspnetcore-8.0
    [ApiController]
    [Route("api/[controller]")]
    public class TripsController : ControllerBase
    {
        private string UserId
        {
            get
            {
                // controller construct 之後才會有權限資料
                return this.User.Identity.GetUserId();
            }
        }

        private readonly ITripService _tripService;
        public TripsController(ITripService tripService)
        {
            _tripService = tripService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripViewModel>>> GetAsync()
        {
            return await _tripService.ReadAsync(this.UserId);
        }

        // Trips222/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostAsync([Bind("Id,UserId,Name,Time")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(trip);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            //return View(trip);
            return null;
        }

        // Trips222/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PutAsync(int id, [Bind("Id,UserId,Name,Time")] Trip trip)
        {
            if (id != trip.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(trip);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!TripExists(trip.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            //return View(trip);
            return null;
        }

        // Trips222/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            //var trip = await _context.Trips.FindAsync(id);
            //if (trip != null)
            //{
            //    _context.Trips.Remove(trip);
            //}

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
