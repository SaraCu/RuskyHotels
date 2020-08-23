using System.ComponentModel.DataAnnotations;
using RuskyHotels.Enums;

namespace RuskyHotels.Models
{
    public class RoomPrice
    {
        [Key]
        public long Id { get; set; }

        [Display(Name = "Room Type")]
        public RoomType RoomType { get; set; }

        public decimal Price { get; set; }
    }
}
