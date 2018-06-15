using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSEFAPI.Model
{
    public class MyConnectionString
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }
    public class ConnectionStrings
    {
        public string ATSEFEntities { get; set; }
        public string AuthEntities { get; set; }
        
    }
}
