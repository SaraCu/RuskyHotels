using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuskyHotels.Models
{
    public class Reservation
    {
       [Key]
        public long Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [ForeignKey(nameof(Room))]
        public long RoomId { get; set; }

        [ForeignKey(nameof(Guest))]
        public long GuestId { get; set; }

        public virtual Guest  Guest{ get; set; }

        public virtual Room Room { get; set; }
    }
}
