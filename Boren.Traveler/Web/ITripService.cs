using Boren.Traveler.Web.Model;

namespace Boren.Traveler.Web
{
    public interface ITripService
    {
        Task<bool> CreateAsync(string userId, TripViewModel model);

        Task<List<TripViewModel>> ReadAsync(string userId);

        Task<bool?> UpdateAsync(string userId, int id, TripViewModel model);

        Task<bool?> DeleteAsync(string userId, int id);
    }
}
