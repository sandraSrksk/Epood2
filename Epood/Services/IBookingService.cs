using Epood.Data;
using Epood.Models;

namespace Epood.Services
{
    public interface IBookingService
    {
        Task<PagedResult<Booking>> List(int page, int pageSize);
        Task<Booking> GetById(int id);
        Task Save(Booking booking);
        Task Delete(int id);
        bool BookingExists(int id);
    }
}
