using System.Collections.Generic;
using System.Threading.Tasks;
using static FlamingoAirwaysAPI.Models.FlamingoAirwaysModel;

namespace FlamingoAirwaysAPI.Models
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetByBookingIdAsync(int bookingId);
        Task AddAsync(Ticket ticket);
        Task DeleteAsync(int ticketId); // New method for deleting a ticket
        Task UpdateAsync (Ticket ticket);   
        Task<Ticket> GetByBookingIdAndTicketIdAsync(int bookingId, int ticketId);
    }
}