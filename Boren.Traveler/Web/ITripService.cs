using Boren.Traveler.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boren.Traveler.Web
{
    public interface ITripService
    {
        Task<bool> CreateAsync(string userId, TripViewModel model);

        Task<IList<object>> ReadAsync();

        Task<bool?> UpdateAsync();

        Task<bool?> DeleteAsync();
    }
}
