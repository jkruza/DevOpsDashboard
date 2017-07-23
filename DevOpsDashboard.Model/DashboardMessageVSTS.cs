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
            Status = "Unknown";

            JObject json = JObject.Parse(EventPayload);
            
            Message = json["message"]["text"].ToString();
            Title = "VSTS Event";
            Category = "General";

            switch (json["eventType"].ToString())
            {
                case "ms.vss-release.deployment-completed-event":
                    Category = "Release";
                    Context = json["resource"]["deployment"]["releaseDefinition"]["id"] + "_" + json["resource"]["deployment"]["releaseEnvironment"]["id"];
                    Title = json["resource"]["deployment"]["releaseDefinition"]["name"] + ": " + json["resource"]["deployment"]["releaseDefinition"]["name"];
                    Status = json["resource"]["deployment"]["deploymentStatus"].ToString();
                    break;

            }

        }
    }
}
/