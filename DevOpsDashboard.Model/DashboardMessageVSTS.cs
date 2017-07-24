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
            
            Message = json["message"]["html"].ToString();
            Title = "VSTS Event";
            Category = "General";
            Details = new string[] { };

            switch (json["eventType"].ToString())
            {
                case "ms.vss-release.deployment-completed-event":
                    Category = "Release";
                    Context = json["resource"]["deployment"]["releaseDefinition"]["id"] + "_" + json["resource"]["deployment"]["releaseEnvironment"]["id"];
                    Title = json["resource"]["deployment"]["releaseDefinition"]["name"].ToString();// + ": " + json["resource"]["deployment"]["releaseDefinition"]["name"];
                    Status = json["resource"]["deployment"]["deploymentStatus"].ToString();
                    break;

                case "ms.vss-release.deployment-started-event":
                    Category = "Release";
                    Context = json["resource"]["release"]["releaseDefinition"]["id"] + "_" + json["resource"]["environment"]["id"];
                    Title = json["resource"]["release"]["releaseDefinition"]["name"].ToString();// + ": " + json["resource"]["deployment"]["releaseDefinition"]["name"];
                    Status = json["resource"]["environment"]["deploymentStatus"].ToString();
                    break;



                case "build.complete":
                    Category = "Build";
                    Context = json["resource"]["definition"]["id"] + "_" + json["resource"]["id"];
                    Title = json["resource"]["definition"]["name"] + ": " + json["resource"]["buildNumber"];
                    Status = json["resource"]["status"].ToString();
                    break;
            }

        }
    }
}