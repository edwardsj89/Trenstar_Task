using BookingSystem.Data.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem
{
    public class BookingChecker
    {
        public int MaxBookings { get; set; } = 20;

        public virtual bool CheckBookingAvailable(DateTime Date, IBookingRepository repository)
        {
            bool IsAvailable = false;

            int bookingCount = repository.GetBookingsForDate(Date).Count();

            if (bookingCount < MaxBookings)
            {
                IsAvailable = true;
            }

            return IsAvailable;
        }
    }
}
