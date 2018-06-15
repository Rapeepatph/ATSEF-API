using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSEFAPI.Model
{
    public class FlightGroup
    {
        public string Arrival { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndingTime { get; set; }
        public List<FlightGroupDetail> ListFlightGroups { get; set; }
        public long P20 { get; set; }
        public long P80 { get; set; }

    }
}
