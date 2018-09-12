using System;
using Newtonsoft.Json;
namespace DevOpsDashboard.Models
{
    public class DashboardMessageGeneric:DashboardMessageBase
    {
        public DashboardMessageGeneric()
        {
            this.Category = "Generic";
            this.Context = "";
            this.Timestamp = DateTime.Now;
            this.Status = "Unknown";
        }
        

        public DashboardMessageGeneric(string Title,string Message,string Category="Generic", string Context="")
        {
            SourceData = String.Empty;
            this.Title = Title;
            this.Message = Message;
            this.Category = Category;
            this.Context = String.Empty;
            Timestamp = DateTime.Now;
            this.Status = "Unknown";
            Details = new string[] { };
        }

        public static DashboardMessageGeneric CreateFromJson(string EventPayload)
        {
            DashboardMessageGeneric msg = new DashboardMessageGeneric();
            msg = JsonConvert.DeserializeObject<DashboardMessageGeneric>(EventPayload);
            msg.SourceData = EventPayload;
            return msg;
        }
    }
}
