﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites.Models
{
    public class Location
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HoursOfOperation { get; set; }
        public List<LocationRating> Ratings { get; set; }
        public string Review { get; set; }
    }
}
