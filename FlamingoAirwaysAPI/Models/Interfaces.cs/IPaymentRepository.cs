using System.Collections.Generic;
using System.Threading.Tasks;
using static FlamingoAirwaysAPI.Models.FlamingoAirwaysModel;

namespace FlamingoAirwaysAPI.Models
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<Payment> GetByIdAsync(int id);
        Task AddAsync(Payment payment);
        Task<Payment> GetByBookingIdAsync(int bookingId);
        Task UpdateAsync(Payment payment);
    }
}