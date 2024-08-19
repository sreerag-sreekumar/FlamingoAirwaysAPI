﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FlamingoAirwaysAPI.Models.FlamingoAirwaysModel;

namespace FlamingoAirwaysAPI.Models
{
    public class FlamingoAirwaysDbContext
    {
        internal object Users;

        public class FlamingoAirwaysDB : DbContext
        {
            public FlamingoAirwaysDB(DbContextOptions<FlamingoAirwaysDB> options) : base(options)
            {

            }
            public DbSet<Flight> Flights { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<Booking> Bookings { get; set; }
            public DbSet<Payment> Payments { get; set; }
            public DbSet<Ticket> Tickets { get; set; }
        }
        
    }
}
