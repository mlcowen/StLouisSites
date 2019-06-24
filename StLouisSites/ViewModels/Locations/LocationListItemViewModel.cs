using StLouisSites.Data;
using StLouisSites.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StLouisSites.ViewModels.Locations
{
    public class LocationListItemViewModel
    {
        public static List<LocationListItemViewModel> GetLocations(ApplicationDbContext context)
        {
            IList<Location> locations = context.Locations.Where(a => a.Id).Include(a => a.LocationReviews).ToList();
            return locations;

            

            //return context.GetMovieRepository()
            //    .GetModels()
            //    .Select(m => new LocationListItemViewModel(m))
            //    .ToList();
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HoursOfOperation { get; set; }
        public List<LocationReview> LocationReviews { get; set; }
        public double AverageRating { get; set; }




        public LocationListItemViewModel(Location location)
        {
            this.Id = Id;
            this.Name = location.Name;
            this.Description = location.Description;
            this.HoursOfOperation = location.HoursOfOperation;
            this.AverageRating = Math.Round(location.LocationReviews.Average(x => x.Rating), 2);

        }

    }
}
