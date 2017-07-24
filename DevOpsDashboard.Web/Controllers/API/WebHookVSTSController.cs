using DevOpsDashboard.Model;
using DevOpsDashboard.Web.Hubs;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DevOpsDashboard.Web.Controllers.API
{
    public class WebHookVSTSController : ApiController
    {
        [HttpPost]
        [Route("api/webhook/vsts")]
        public async Task<DashboardMessageVSTS> PostRawBufferManual()
        {
            string RawJSON = await Request.Content.ReadAsStringAsync();
            DashboardMessageVSTS msg = new DashboardMessageVSTS(RawJSON);
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<DashboardMessageHub>();
            hubContext.Clients.All.broadcastDashboardMessage(msg);
            DashboardMessageCache.Add(msg);
            return msg;

        }

    }
}