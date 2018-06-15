using System;
using System.Collections.Generic;

namespace ATSEFAPI.DBModels
{
    public partial class Fix
    {
        public string Name { get; set; }
        public string LatDegree { get; set; }
        public string LongDegree { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
