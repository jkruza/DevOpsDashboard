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

        public override System.Threading.Tasks.Task OnConnected()
        {
            Clients.Caller.pushFromCache(DashboardMessageCache.GetAll());
            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnReconnected()
        {
            Clients.Caller.pushFromCache(DashboardMessageCache.GetAll());
            return base.OnConnected();
        }


    }
}