using System;
using System.Collections.Generic;
using System.Text;

namespace ExploreTheWorld.Data.Entities
{
    public class Airport
    {
        public string Name { get; set; }
        public Country Country { get; set; }
        public string City { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        /// <summary>
        /// 3-letter code
        /// </summary>
        public string ITATA { get; set; }
        /// <summary>
        /// 4-letter code
        /// </summary>
        public string ICAO { get; set; }
    }
}
