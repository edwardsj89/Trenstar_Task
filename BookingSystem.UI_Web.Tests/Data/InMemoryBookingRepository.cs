using BookingSystem.Data.Database.Models;
using BookingSystem.Data.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.UI_Web.Tests.Data
{
    public class InMemoryBookingRepository : IBookingRepository, IDisposable
    {
        private List<Booking> Bookings = new List<Booking>();

        public InMemoryBookingRepository()
        {
            SeedDate();
        }

        private void SeedDate()
        {
            var date = new DateTime(2019, 3, 13);
            for (int i = 0; i < 20; i++)
            {
                Bookings.Add(
                    new Booking { Date = date, Email = "dummy@email.com", Name = "Tom" }
                );
            }
        }

        public Booking CreateBooking(Booking booking)
        {
            Bookings.Add(booking);
            return booking;
        }

        public void Dispose()
        {
            Bookings = null;
        }

        public IEnumerable<Booking> GetBookingsForDate(DateTime date)
        {
            return Bookings.Where(w => w.Date == date);
        }
    }
}
