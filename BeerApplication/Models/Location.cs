using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerApplication.Models
{
    public class LocationDetail
    {
        public string locality { get; set; }
    }
    public class Location
    {
        public string message { get; set; }
        public List<LocationDetail> data { get; set; }
    }
}