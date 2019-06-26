using StLouisSites.Data;
using StLouisSites.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites.ViewModels.Locations
{
    public class LocationCreateViewModel
    {
        
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HoursOfOperation { get; set; }
        public string Address { get; set; }
        public string Region { get; set; }


        internal void Persist(ApplicationDbContext context)
        {
            Location location = new Location
            {
                //Id = this.Id,
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
