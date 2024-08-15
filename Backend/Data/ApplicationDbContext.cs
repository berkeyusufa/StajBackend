using Microsoft.EntityFrameworkCore;
using BusManagement.Models;
using System.Linq;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System;
using BusManagement.Model1;

namespace BusManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<BusRoute> BusRoutes { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<BusManagement.Models.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Driver>().HasKey(d => d.Id);
            modelBuilder.Entity<Bus>().HasKey(b => b.Id);
            modelBuilder.Entity<BusRoute>().HasKey(br => br.Id);
            modelBuilder.Entity<Region>().HasKey(r => r.Id);
            modelBuilder.Entity<BusManagement.Models.Task>().HasKey(t => t.Id);
            modelBuilder.Entity<User>().HasKey(u => u.Id);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "Berke",
                    PasswordHash = HashPassword("123456")
                }
            );
        }

        private static string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return $"{Convert.ToBase64String(salt)}.{hashed}";
        }

        public void Seed()
        {
            if (!Drivers.Any())
            {
                var drivers = new[]
                {
                    new Driver { Name = "Ahmet", Surname = "Gür", Age = 40 },
                    new Driver { Name = "Mazhar", Surname = "Özer", Age = 41 },
                    new Driver { Name = "Murat", Surname = "Atay", Age = 42 },
                    new Driver { Name = "Bahattin", Surname = "Tetik", Age = 43 },
                    new Driver { Name = "Osman", Surname = "Işık", Age = 44 }
                };

                Drivers.AddRange(drivers);
                SaveChanges();
            }

            if (!Buses.Any())
            {
                var buses = new[]
                {
                    new Bus { DoorNumber = "C-446", PlateNumber = "34 DE 5962", Photo = "", CreatedDate = DateTime.Now },
                    new Bus { DoorNumber = "B-1639", PlateNumber = "34 LR 1041", Photo = "", CreatedDate = DateTime.Now },
                    new Bus { DoorNumber = "A-1679", PlateNumber = "34 KP 0418", Photo = "", CreatedDate = DateTime.Now },
                    new Bus { DoorNumber = "D-056", PlateNumber = "34 HCK 459", Photo = "", CreatedDate = DateTime.Now },
                    new Bus { DoorNumber = "C-773", PlateNumber = "34 HO 3306", Photo = "", CreatedDate = DateTime.Now }
                };

                Buses.AddRange(buses);
            }

            if (!Regions.Any())
            {
                var regions = new[]
                {
                    new Region { RegionName = "Fatih" },
                    new Region { RegionName = "Sultangazi" },
                    new Region { RegionName = "Bayrampaşa" },
                    new Region { RegionName = "Beyoğlu" },
                    new Region { RegionName = "Eyüp" }
                };

                Regions.AddRange(regions);
            }

            if (!BusRoutes.Any())
            {
                var routes = new[]
                {
                    new BusRoute { RouteName = "Draman-Eminönü", RouteID = "90", RegionId = 1 },
                    new BusRoute { RouteName = "Topkapı-Edirnekapı", RouteID = "87", RegionId = 1 },
                    new BusRoute { RouteName = "Cevatpaşa-Eminönü", RouteID = "32", RegionId = 3 },
                    new BusRoute { RouteName = "Sultançiftliği-Eminönü", RouteID = "336E", RegionId = 2 },
                    new BusRoute { RouteName = "KocaMustafaPaşa-Eminönü", RouteID = "35", RegionId = 1 }
                };

                BusRoutes.AddRange(routes);
            }

            SaveChanges();
        }
    }
}
