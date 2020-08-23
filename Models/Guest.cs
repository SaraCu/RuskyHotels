using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RuskyHotels.Models
{
    public class Guest
    {
        public Guest()
        {
            Reservations = new List<Reservation>();
        }

        [Key]
        public long Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [InverseProperty(nameof(Reservation.Guest))]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
