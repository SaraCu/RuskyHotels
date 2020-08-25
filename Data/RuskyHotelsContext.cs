using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RuskyHotels.Models;

    public class RuskyHotelsContext : DbContext
    {
        public RuskyHotelsContext (DbContextOptions<RuskyHotelsContext> options)
            : base(options)
        {
        }

        public DbSet<RuskyHotels.Models.Reservation> Reservation { get; set; }

        public DbSet<RuskyHotels.Models.ReservationViewModel> ReservationViewModel { get; set; }
    }
