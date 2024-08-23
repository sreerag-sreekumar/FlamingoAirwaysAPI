using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using static FlamingoAirwaysAPI.Models.FlamingoAirwaysDbContext;
using static FlamingoAirwaysAPI.Models.FlamingoAirwaysModel;

namespace FlamingoAirwaysAPI.Models
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly FlamingoAirwaysDB _context;

        public PaymentRepository(FlamingoAirwaysDB context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment> GetByIdAsync(int id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public async Task AddAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<Payment> GetByBookingIdAsync(int bookingId)
        {
            return await _context.Payments.SingleOrDefaultAsync(p => p.BookingIdFK == bookingId);
        }

        public async Task UpdateAsync(Payment payment)
        {
            _context.Payments.Update(payment);
            _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }
    }
}