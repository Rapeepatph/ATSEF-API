using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSEFAPI.Model
{
    public class FlightGroupDetail
    {
        public string Aircraft { get; set; }
        public string RunwayHeading { get; set; }
        public long Amount { get; set; }
        public string Arrival { get; set; }
        public int? SecondEntrySector { get; set; }
        public long Min { get; set; }
        public long Max { get; set; }
        public decimal Avg { get; set; }
        public long P20 { get; set; }
        public long P80 { get; set; }
        public long P15 { get; set; }
        public long P85 { get; set; }
    }
}
