using System;
using System.Collections.Generic;

namespace ATSEFAPI.DBModels
{
    public partial class GroupProfile
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool? Status { get; set; }
    }
}
