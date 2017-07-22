using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsDashboard.Model
{
    public class DashboardMessageGitHub:DashboadMessageBase
    {
        public DashboardMessageGitHub(string EventPayload, string EventType)
        {
            SourceData = EventPayload;
            Title = "Github Event";
            Message = "Github Event stub message";
            Category = "General";
            Context = String.Empty;
            Timestamp = DateTime.Now;
        }
    }
}
