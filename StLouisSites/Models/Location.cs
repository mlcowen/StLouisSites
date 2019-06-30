using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HoursOfOperation { get; set; }
        public string Address { get; set; }
        public string Region { get; set; }
        public List<LocationReview> LocationReviews { get; set; }
        public Category Category { get; set; }
        public List<CategoryLocation> CategoryLocations { get; set; }
    }
}
