using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;

namespace Domain.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("HotelAppConnectionString")
        {

        }

        #region DbSet
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<HotelService> HotelServices { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder ModelBuilder)
        {
            base.OnModelCreating(ModelBuilder);

            ModelBuilder.Entity<HotelService>()
                .HasKey(hs => new { hs.HotelId, hs.ServiceId });
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}
