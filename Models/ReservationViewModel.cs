using System;
using System.ComponentModel.DataAnnotations;
using RuskyHotels.Enums;

namespace RuskyHotels.Models
{
    public class ReservationViewModel 
    {
        public long Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name ="Room Type")]
        public RoomType RoomType { get; set; }

        [Display(Name ="Price Per Night")]
        public decimal PricePerNight { get; set; }

        [Display(Name ="Total Price")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }

    }
}
