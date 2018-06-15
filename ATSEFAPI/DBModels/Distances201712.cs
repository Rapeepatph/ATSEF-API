using System;
using System.Collections.Generic;

namespace ATSEFAPI.DBModels
{
    public partial class Distances201712
    {
        public int FlightId { get; set; }
        public string Callsign { get; set; }
        public string Actype { get; set; }
        public string Dep { get; set; }
        public string Dest { get; set; }
        public string Type { get; set; }
        public DateTime? Atd { get; set; }
        public DateTime? Ata { get; set; }
        public string DepPhase { get; set; }
        public string EnrPhase { get; set; }
        public string ArrOuterPhase { get; set; }
        public string ArrInnerPhase { get; set; }
        public double? AllGc { get; set; }
        public double? EnrGc { get; set; }
        public double? EnrGcD { get; set; }
        public double? EnrGcG { get; set; }
        public double? ArrOuterGc { get; set; }
        public double? AllPtp { get; set; }
        public double? EnrPtp { get; set; }
        public double? DepActual { get; set; }
        public double? EnrActual { get; set; }
        public double? ArrOuterActual { get; set; }
        public double? ArrInnerActual { get; set; }
        public double? DepMin { get; set; }
        public double? EnrMin { get; set; }
        public double? ArrOuterMin { get; set; }
        public double? ArrInnerMin { get; set; }
        public string Runway { get; set; }
        public double? ArrAngle { get; set; }
        public double? ArrInnerAngle { get; set; }
    }
}
