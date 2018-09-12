using System;

namespace DevOpsDashboard.Models
{
    public class DashboardMessageBase
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }
        public string SourceData { get; set; }
        public DateTime Timestamp { get; set; }
        public string[] Details { get; set; }

        public string Status { get; set; }
    }
}
