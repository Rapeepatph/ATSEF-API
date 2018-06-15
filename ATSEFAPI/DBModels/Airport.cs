using System;
using System.Collections.Generic;

namespace ATSEFAPI.DBModels
{
    public partial class Airport
    {
        public Airport()
        {
            RunwayHeading = new HashSet<RunwayHeading>();
        }

        public uint Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Tma { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? Elevation { get; set; }
        public double? X { get; set; }
        public double? Y { get; set; }

        public ICollection<RunwayHeading> RunwayHeading { get; set; }
    }
}
