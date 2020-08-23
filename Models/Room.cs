using System.ComponentModel.DataAnnotations;
using RuskyHotels.Enums;

namespace RuskyHotels.Models
{
    public class Room
    {
        [Key]
        public long Id { get; set; }

        [Display(Name = "Room Type")]
        public RoomType RoomType { get; set; }

        [Display(Name = "Floor")]
        public int Foor { get; set; }

        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }
    }
}
