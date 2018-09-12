using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace DevOpsDashboard.Models
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

                case "pull_request":
                    Category = "Code";
                    Context = "";
                    ParseEventPullRequest(EventPayload);
                    
                    break;


                default:
                    Title = "Github Event";
                    Message = "Github Event stub message";
                    Category = "General";
                    Context = String.Empty;
                    Details = new string[] { };
                    break;
            }

            
        }

        private void ParseEventPullRequest(string EventJSON)
        {
            JObject json = JObject.Parse(EventJSON);
            Title = String.Format("Pull request in '{0}'", json["repository"]["name"]);
            Message = String.Format("{0} has {1} pull request to {2} branch {3}", json["sender"]["login"], json["action"], json["repository"]["name"],json["pull_request"]["base"]["ref"]);
            Details = new string[] { json["pull_request"]["title"].ToString() };
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
