using StLouisSites.Data;
using StLouisSites.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StLouisSites.ViewModels.Locations
{
    public class LocationCreateViewModel
    {
        
        //public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Description { get; set; }
        public string HoursOfOperation { get; set; }
        public string Address { get; set; }

        public List<Category> Categories { get; set; }

        [Required]
        public string Region { get; set; }


        public static List<LocationCreateViewModel> GetCategories(ApplicationDbContext context)
        {
            IList<Category> categories = context.Categories.ToList();


            //declare a new list. This will be used in our foreach loop to hold each individual instance of a category 
            //we add data to this list at the end of our foreach loop 
            List<Category> viewDataList = new List<Category>();

            foreach ( var category in categories)
            {
                //every time we loop through we create a new instance of the LocationCreateViewModel. 
                //look up recursion to get an explanation of how this works
                Category thisSpecificCategory = new Category();

                thisSpecificCategory.CategoryLocations = category;

            }
        }

        internal void Persist(ApplicationDbContext context)
        {
            Location location = new Location
            {
                //Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                HoursOfOperation = this.HoursOfOperation,
                Address = this.Address,
                Region = this.Region,
               // Category = this.Categories // this may need to be in a separate error since it writes to a separate database.

            };

            context.Add(location);
            context.SaveChanges();
        }
    }
}
