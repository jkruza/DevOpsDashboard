using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using DevOpsDashboard.Model;

namespace DevOpsDashboard.Web.Hubs
{
    public class DashboardMessageHub : Hub
    {
        
        public void BroadcastDashboardMessage(DashboardMessageBase msg)
        {
            Clients.All.broadcastDashboardMessage(msg);
        }
        
    }
}