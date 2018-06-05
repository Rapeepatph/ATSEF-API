using System;
using System.Collections.Generic;

namespace ATSEFAPI.DBModels
{
    public partial class FlightProfile
    {
        public uint Id { get; set; }
        public string Callsign { get; set; }
        public string Squawk { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public string DeptTma { get; set; }
        public string DestTma { get; set; }
        public double? StartRadian { get; set; }
        public double? EndRadian { get; set; }
        public string AccSectors { get; set; }
        public int? FlightType { get; set; }
        public double? FirstX { get; set; }
        public double? FirstY { get; set; }
        public int? FirstLevel { get; set; }
        public string FirstTime { get; set; }
        public double? LastX { get; set; }
        public double? LastY { get; set; }
        public int? LastLevel { get; set; }
        public string LastTime { get; set; }
        public string Waypoints { get; set; }
        public double? DirectDistance { get; set; }
        public double? FirstExitX { get; set; }
        public double? FirstExitY { get; set; }
        public int? FirstExitLevel { get; set; }
        public string FirstExitTime { get; set; }
        public double? FirstEntX { get; set; }
        public double? FirstEntY { get; set; }
        public int? FirstEntLevel { get; set; }
        public string FirstEntTime { get; set; }
        public double? SecondEntX { get; set; }
        public double? SecondEntY { get; set; }
        public int? SecondEntLevel { get; set; }
        public string SecondEntTime { get; set; }
        public double? FirstEnrDistance { get; set; }
        public long? FirstEnrTime { get; set; }
        public double? SecondEnrDistance { get; set; }
        public long? SecondEnrTime { get; set; }
    }
}
