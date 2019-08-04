using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Data.Database.Context;
using BookingSystem.Data.Database.Models;

namespace BookingSystem.Data.Database.Repositories
{
    public class BookingRepository : IDisposable, IBookingRepository
    {
        private readonly BookingSystem_DbContext _contaxt = new BookingSystem_DbContext();

        public Booking CreateBooking(Booking booking)
        {
            var result = _contaxt.Bookings.Add(booking);
            _contaxt.SaveChanges();
            return result;
        }

        public void DeleteBooking(Booking booking)
        {
            _contaxt.Bookings.Remove(booking);
        }

        public Booking EditBooking(Booking booking)
        {
            var entity = _contaxt.Bookings.Find(booking.ID);
            _contaxt.Entry(entity).CurrentValues.SetValues(booking);
            _contaxt.SaveChanges();
            return entity;
        }

        public Booking GetBookingByEmail(string email)
        {
            return _contaxt.Bookings.SingleOrDefault(w => w.Email == email);
        }

        public IEnumerable<Booking> GetBookingsForDate(DateTime date)
        {
            return _contaxt.Bookings.Where(w => w.Date == date);
        }

        public void Dispose()
        {
            if (_contaxt != null)
            {
                _contaxt.Dispose();
            }
        }

    }
}
