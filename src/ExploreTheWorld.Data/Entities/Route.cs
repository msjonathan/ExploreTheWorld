using System;
using System.Collections.Generic;
using System.Text;

namespace ExploreTheWorld.Data.Entities
{
   public class Route
    {
        public Airline Airline { get; set; }
        public Airport SourceAirport { get; set; }
        public Airport DestinationAirport { get; set; }
    }
}
