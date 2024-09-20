using System;
using MagicResort_ResortAPI.Models;
using MagicResort_ResortAPI.Models.DTO;

namespace MagicResort_ResortAPI.Data
{
	public static class ResortStore		// static because, the class is used as a data storage
	{
        // Creating a list of resorts as data
        public static List<ResortDTO> ResortList = new List<ResortDTO> {
                    new ResortDTO { ResortId = 1, ResortName = "Pool View", Occupancy = 4, Sqft = 100 },
                    new ResortDTO { ResortId = 2, ResortName = "Sunny Beach", Occupancy = 6, Sqft = 200 },
                    new ResortDTO { ResortId = 3, ResortName = "Mountain Retreat", Occupancy = 8, Sqft = 300 },
                    new ResortDTO { ResortId = 4, ResortName = "Forest Oasis", Occupancy = 3, Sqft = 100 },
                    new ResortDTO { ResortId = 5, ResortName = "Desert Oasis", Occupancy = 2, Sqft = 70 }
                }; 
	}
}

