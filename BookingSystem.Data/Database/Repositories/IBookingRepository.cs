using System;
using System.Collections.Generic;
using BookingSystem.Data.Database.Models;

namespace BookingSystem.Data.Database.Repositories
{
    public interface IBookingRepository
    {
        Booking CreateBooking(Booking booking);
        void DeleteBooking(Booking booking);
        void Dispose();
        Booking EditBooking(Booking booking);
        Booking GetBookingByEmail(string email);
        IEnumerable<Booking> GetBookingsForDate(DateTime date);
    }
}