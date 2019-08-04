using System;
using BookingSystem.UI_Web.Tests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookingSystem.UI_Web.Tests.BookingSystem_Tests
{
    [TestClass]
    public class BookingCheckerTests
    {
        [TestMethod]
        public void NotAvailableIfMaxExceeded()
        {
            using (var repo = new InMemoryBookingRepository())
            {
                var date = new DateTime(2019, 3, 13);
                var checker = new BookingChecker();
                var available = checker.CheckBookingAvailable(date, repo);

                Assert.IsFalse(available);
            }
        }
    }
}
