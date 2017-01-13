using System;
using System.Collections.Generic;
using System.Text;

namespace ExploreTheWorld.Data.Entities
{
    public class Airline
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        /// <summary>
        /// 2-letter code
        /// </summary>
        public string ITATA { get; set; }
        /// <summary>
        /// 3-letter code
        /// </summary>
        public string ICAO { get; set; }
        public Country CountryOfOrigin { get; set; }
    }
}
