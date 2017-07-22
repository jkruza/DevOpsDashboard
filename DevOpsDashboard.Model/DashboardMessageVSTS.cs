using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsDashboard.Model
{
    public class DashboardMessageVSTS:DashboadMessageBase
    {
        public DashboardMessageVSTS(string EventPayload)
        {
            SourceData = EventPayload;
            Title = "VSTS Event";
            Message = "VSTS event stub message";
            Category = "General";
            Context = String.Empty;
            Timestamp = DateTime.Now;
        }
    }
}
