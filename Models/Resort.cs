using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WanderHub_ResortAPI.Models
{
	public class Resort
	{
		[Key]       // Built-in data annotations for Primary key
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]		// Database automatically handling the ID
        public int ResortId { get; set; }

		public string ResortName { get; set; }
		public string Details { get; set; }
		public double Rate { get; set; }
		public int Sqft { get; set; }
		public int Occupancy { get; set; }
		public string ImageUrl { get; set; }
		public string Amenity { get; set; }
		public DateTime CreatedDate { get; set; }
        public DateTime UpdateddDate { get; set; }
    }
}

// NuGet packages for Entity Framework Core
// Microsoft.EntityFrameworkCore.SqlServer (based on the .net version)
	// Dependacies will be automatically installed >> Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.Relational
// Microsoft.EntityFrameworkCore.Tools
