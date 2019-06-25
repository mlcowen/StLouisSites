using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StLouisSites.Models
{
    public class LocationReview
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string ReviewHeadline { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
    }
}
