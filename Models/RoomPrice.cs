using System.ComponentModel.DataAnnotations;
using RuskyHotels.Enums;

namespace RuskyHotels.Models
{
    public class RoomPrice
    {
        [Key]
        public long Id { get; set; }

        public RoomType RoomType { get; set; }

        public decimal Price { get; set; }
    }
}
