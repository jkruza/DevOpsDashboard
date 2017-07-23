using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsDashboard.Model
{
    public class DashboardMessageGitHub : DashboardMessageBase
    {
        public DashboardMessageGitHub(string EventPayload, string EventType)
        {
            SourceData = EventPayload;
            this.Status = "Unknown";
            Timestamp = DateTime.Now;

            switch (EventType.ToLower())
            {
                case "push": 
                    Category = "Code";
                    Context = "";
                    ParseEventPush(EventPayload);

                    break;


                default:
                    Title = "Github Event";
                    Message = "Github Event stub message";
                    Category = "General";
                    Context = String.Empty;
                    break;
            }

            
        }

        private void ParseEventPush(string EventJSON)
        {
            JObject json = JObject.Parse(EventJSON);
            Title = String.Format("Code push to '{0}'", json["repository"]["name"]);
            Message = String.Format("{0} has pushed commits to repository '{1}'", json["pusher"]["name"], json["repository"]["name"]);
            Details= json["commits"].Select<JToken,string>(x => x["message"].ToString()).ToArray();
        }
    }
}
