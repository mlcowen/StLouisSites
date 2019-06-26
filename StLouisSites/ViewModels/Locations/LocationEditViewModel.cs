using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StLouisSites.Data;
using StLouisSites.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace StLouisSites.ViewModels.Locations
{
    public class LocationEditViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Description { get; set; }
        public string HoursOfOperation { get; set; }
        public string Address { get; set; }

        [Required]
        public string Region { get; set; }

        public LocationEditViewModel() { }

        public LocationEditViewModel(int LocationId, ApplicationDbContext context)
        {
            Location location = context.Locations.Find(LocationId);

            this.Name = location.Name;
            this.Description = location.Description;
            this.HoursOfOperation = location.HoursOfOperation;
            this.Address = location.Address;
            this.Region = location.Region;
        }

        public void Persist(int LocationId, ApplicationDbContext context)
        {
            Location location = new Location
            {
                Id = LocationId,
                Name = this.Name,
                Description = this.Description,
                HoursOfOperation = this.HoursOfOperation,
                Address = this.Address,
                Region = this.Region
            };
            context.Add(location);
            context.SaveChanges();
        }
    }
}

