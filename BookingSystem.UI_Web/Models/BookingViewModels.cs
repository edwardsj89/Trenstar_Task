using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingSystem.UI_Web.Models
{
    public class DateCheckViewModel
    {

        [Display(Name = "Booking Date")]
        [Required(ErrorMessage = "A booking date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
    }
    public class BookingViewModel : DateCheckViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}