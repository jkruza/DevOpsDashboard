using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsDashboard.Model
{
    public class DashboadMessageBase
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }
        public string SourceData { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
