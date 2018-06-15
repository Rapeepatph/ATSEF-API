using System;
using System.Collections.Generic;

namespace ATSEFAPI.DBModels
{
    public partial class RunwayHeading
    {
        public uint Id { get; set; }
        public string Sign { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? Elevation { get; set; }
        public double? Heading { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }
        public uint AirportId { get; set; }

        public Airport Airport { get; set; }
    }
}
