using Boren.Traveler.Data;
using Boren.Traveler.Web;
using Boren.Traveler.Web.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boren.Traveler.Service
{
    public class TripService : ITripService
    {
        private readonly TravelerDbContext _dbContext;
        public TripService(TravelerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> CreateAsync(string userId, TripViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TripViewModel>> ReadAsync(string userId)
        {
            return await _dbContext.Trips.Where(x => x.UserId == userId).OrderByDescending(x => x.Id).Select(x => new TripViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Start = x.Start,
                End = x.End
            }).ToListAsync();
        }

        public Task<bool?> UpdateAsync(string userId, int id, TripViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteAsync(string userId, int id)
        {
            throw new NotImplementedException();
        }
    }
}
