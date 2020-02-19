using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DiversHotel.Models;
namespace DiversHotel.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomInterval> RoomIntervals { get; set; }
        public DbSet<RoomPrice> RoomPrices { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealSeason> MealSeasons { get; set; }
        public DbSet<MealPrice> MealPrices { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
