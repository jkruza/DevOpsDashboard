using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DevOpsDashboard.Models;
using System.Threading.Tasks;

namespace DevOpsDashboard.Web.Controllers.API
{
    [ApiController]
    public class WebHookVSTSController : ControllerBase
    {
        [HttpPost]
        [Route("api/webhook/vsts")]
        public async Task<DashboardMessageVSTS> PostRawBufferManual()
        {
            string RawJSON = await Request.Body.ReadAsStringAsync();
            DashboardMessageVSTS msg = new DashboardMessageVSTS(RawJSON);
            //var hubContext = GlobalHost.ConnectionManager.GetHubContext<DashboardMessageHub>();
            //hubContext.Clients.All.broadcastDashboardMessage(msg);
            //DashboardMessageCache.Add(msg);
            return msg;

        }

    }
}