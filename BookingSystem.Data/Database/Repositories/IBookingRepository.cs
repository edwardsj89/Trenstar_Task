using System;
using System.Collections.Generic;
using BookingSystem.Data.Database.Models;

namespace BookingSystem.Data.Database.Repositories
{
    public interface IBookingRepository
    {
        Booking CreateBooking(Booking booking);
        IEnumerable<Booking> GetBookingsForDate(DateTime date);

        void Dispose();
    }
}