using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsDashboard.Model
{
    class DashboardMessageGeneric:DashboadMessageBase
    {
        public DashboardMessageGeneric(string EventPayload)
        {
            SourceData = EventPayload;
            Title = "Generic Event";
            Message = "Generic event stub message";
            Category = "General";
            Context = String.Empty;
            Timestamp = DateTime.Now;
        }

        public DashboardMessageGeneric(string Title,string Message,string Category="Generic", string Context="")
        {
            SourceData = String.Empty;
            this.Title = Title;
            this.Message = Message;
            this.Category = Category;
            this.Context = String.Empty;
            Timestamp = DateTime.Now;
        }
    }
}
