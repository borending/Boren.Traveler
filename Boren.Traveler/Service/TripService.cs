using Boren.Traveler.Web;
using Boren.Traveler.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boren.Traveler.Service
{
    public class TripService : ITripService
    {
        public Task<bool> CreateAsync(string userId, TripViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IList<object>> ReadAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool?> UpdateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool?> DeleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
