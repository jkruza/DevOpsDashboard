using System.Linq;
using DevOpsDashboard.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace DevOpsDashboard.Hubs
{
    public class DashboardMessageHub : Hub
    {
        

        public void BroadcastDashboardMessage(DashboardMessageBase msg)
        {
            Clients.All.SendAsync("broadcastDashboardMessage",msg);
        }

//PORT issue - support onConnect?
/* 
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
*/

    }
}