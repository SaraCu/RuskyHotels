using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RuskyHotels.Enums;

namespace RuskyHotels.Models
{
    public class Reservation
    {
        [Key]
        public long Id { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public decimal PricePerNight { get; set; }

        public decimal TotalPrice { get; set; }

        public string  Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [ForeignKey(nameof(Room))]
        public long RoomId { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Room Room { get; set; }
    }
}
