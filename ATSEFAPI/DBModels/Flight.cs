using System;
using System.Collections.Generic;

namespace ATSEFAPI.DBModels
{
    public partial class Flight
    {
        public uint Id { get; set; }
        public string FlightNumber { get; set; }
        public string AircraftType { get; set; }
        public DateTimeOffset IssuedDate { get; set; }
    }
}
