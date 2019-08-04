using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookingSystem.Data.Database.Models;
using BookingSystem.Data.Database.Repositories;
using BookingSystem.UI_Web.Models;

namespace BookingSystem.UI_Web.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }

        // POST: Booking
        [HttpPost]
        public ActionResult Index(DateCheckViewModel model)
        {
            using (var repo = new BookingRepository())
            {
                var available = new BookingChecker(repo).CheckBookingAvailable(model.Date);
                if (!available)
                {
                    string message = $"There are no more bookings available for the selected date {model.Date.ToShortDateString()}";
                    ModelState.AddModelError("Date", message);
                    return RedirectToAction(nameof(MessageBooking), new { Message = message });

                }
                if (ModelState.IsValid)
                {
                    return RedirectToAction(nameof(CreateBooking), new { Date = model.Date });
                }
                return View(model);
            }
        }

        public ActionResult CreateBooking(DateTime Date)
        {
            var model = new BookingViewModel { Date = Date };
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateBooking(BookingViewModel model)
        {
            using (var repo = new BookingRepository())
            {
                //Double check no new booking was made while user captured data
                var available = new BookingChecker(repo).CheckBookingAvailable(model.Date);
                if (!available)
                {
                    string message = $"There are no more bookings available for the selected date {model.Date.ToShortDateString()}";
                    ModelState.AddModelError("Date", message);
                    return RedirectToAction(nameof(MessageBooking), new { Message = message });
                }
                if (ModelState.IsValid)
                {
                    var entity = new Booking {
                        Date = model.Date,
                        Name = model.Name,
                        Email = model.Email
                    };
                    var result = repo.CreateBooking(entity);

                    if (result.ID != 0)
                    {
                        return RedirectToAction(nameof(MessageBooking), new { Message = $"You're booking was successfully created.{Environment.NewLine}Thank you." });
                    }
                }

                return View(model);
            }

        }

        public ActionResult MessageBooking(string Message)
        {
            ViewBag.Message = Message;
            return View();
        }
    }
}