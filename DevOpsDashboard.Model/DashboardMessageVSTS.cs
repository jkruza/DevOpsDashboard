using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsDashboard.Model
{
    public class DashboardMessageVSTS:DashboardMessageBase
    {
        public DashboardMessageVSTS(string EventPayload)
        {
            SourceData = EventPayload;
            Context = String.Empty;
            Timestamp = DateTime.Now;

            JObject json = JObject.Parse(EventPayload);
            
            Message = json["message"]["text"].ToString();
            
            Title = "VSTS Event";
            Category = "General";
        }
    }
}
