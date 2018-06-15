using System;
using System.Collections.Generic;

namespace ATSEFAPI.DBModels
{
    public partial class GroupStatistic
    {
        public uint Id { get; set; }
        public string Arrival { get; set; }
        public string RunwayHeading { get; set; }
        public string Aircraft { get; set; }
        public int? SecondEntrySector { get; set; }
        public long? Min { get; set; }
        public long? Max { get; set; }
        public long? Avg { get; set; }
        public long? P15 { get; set; }
        public long? P20 { get; set; }
        public long? P80 { get; set; }
        public long? P85 { get; set; }
        public long? Predict { get; set; }
        public int? ProfileId { get; set; }
    }
}
