using System;
using System.ComponentModel.DataAnnotations;

namespace WanderHub_ResortAPI.Models.DTO
{
	public class ResortDTO
	{
		// put only the properties (from Resort Model) that need to be displayed to API users.
		public int ResortId { get; set; }


		[Required]                          // Built-in data annotations for validation in .NET code. Need to import the DataAnnotations class.
		[MaxLength(30)]							// If these are not met when creating a new record, it gives an error.
        public string ResortName { get; set; }

        public string Details { get; set; }

        [Required]
        public double Rate { get; set; }
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }

    }
}

