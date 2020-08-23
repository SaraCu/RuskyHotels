using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RuskyHotels.Enums;

namespace RuskyHotels.Models
{
    public class Room
    {
        public Room()
        {
        }

        [Key]
        public long Id { get; set; }

        public RoomType RoomType { get; set; }

        [ForeignKey(nameof(RoomPrice))]
        public long RoomPriceId { get; set; }

        public virtual RoomPrice RoomPrice { get; set; }
    }
}
