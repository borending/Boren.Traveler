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
        private readonly string _userId;
        public TripController()
        {
            _userId = this.User.Identity.GetUserId();
        }

        public IActionResult List()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            //return View(await _context.Trips.ToListAsync());
            return View();
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
            return View(trip);
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
            return View(trip);
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
