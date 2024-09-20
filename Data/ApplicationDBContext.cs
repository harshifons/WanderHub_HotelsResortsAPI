using System;
using WanderHub_ResortAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WanderHub_ResortAPI.Data
{
	public class ApplicationDBContext: DbContext    // Inheriting DbContext gives built-in functions in Entity Framework Core. 
    {
        // Creating the Resort table
		public DbSet<Resort> Resort { get; set; }   // Table name in the database
                                                    // LINQ statements will be used to query DB set. LINQ quesries will be automatically translated into sql queries by entity framework core.

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
		{
		}

        // add migration and update-database
        // added NuGet package Microsoft.EntityFrameworkCore.Design to support dotnet-ef



        // Populating the Resort table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Resort>().HasData()
            modelBuilder.Entity<Resort>().HasData(
              new Resort
              {
                  ResortId = 1,
                  ResortName = "Mountain Retreat",
                  Details = "A serene getaway blending luxury and nature, perfect for relaxation and adventure.",
                  ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg",
                  Occupancy = 4,
                  Rate = 200,
                  Sqft = 550,
                  Amenity = "",
                  CreatedDate = DateTime.Now
              },
              new Resort
              {
                  ResortId = 2,
                  ResortName = "Sunny Beach Resort",
                  Details = "A serene getaway blending luxury and nature, perfect for relaxation and adventure.",
                  ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa1.jpg",
                  Occupancy = 4,
                  Rate = 300,
                  Sqft = 550,
                  Amenity = "",
                  CreatedDate = DateTime.Now
              },
              new Resort
              {
                  ResortId = 3,
                  ResortName = "Luxury Forest Oasis",
                  Details = "A serene getaway blending luxury and nature, perfect for relaxation and adventure.",
                  ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg",
                  Occupancy = 4,
                  Rate = 400,
                  Sqft = 750,
                  Amenity = "",
                  CreatedDate = DateTime.Now
              },
              new Resort
              {
                  ResortId = 4,
                  ResortName = "Royal Desert Villa",
                  Details = "A serene getaway blending luxury and nature, perfect for relaxation and adventure.",
                  ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg",
                  Occupancy = 4,
                  Rate = 550,
                  Sqft = 900,
                  Amenity = "",
                  CreatedDate = DateTime.Now
              },
              new Resort
              {
                  ResortId = 5,
                  ResortName = "Diamond Pool Resort",
                  Details = "A serene getaway blending luxury and nature, perfect for relaxation and adventure..",
                  ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg",
                  Occupancy = 4,
                  Rate = 600,
                  Sqft = 1100,
                  Amenity = "",
                  CreatedDate = DateTime.Now
              }
            );
        }


    }
}

