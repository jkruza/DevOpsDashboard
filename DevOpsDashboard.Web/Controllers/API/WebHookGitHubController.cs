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
    public class WebHookGitHubController : ApiController
    {



        [HttpPost]
        [Route("api/webhook/github")]
        public async Task<DashboardMessageGitHub> PostRawBufferManual()
        {
            
            IEnumerable<string> headerValues = Request.Headers.GetValues("X-GitHub-Event");
            string GitHubEvent = headerValues.FirstOrDefault();

            string RawJSON = await Request.Content.ReadAsStringAsync();

            DashboardMessageGitHub msg = new DashboardMessageGitHub(RawJSON, GitHubEvent);

            var hubContext = GlobalHost.ConnectionManager.GetHubContext<DashboardMessageHub>();
            hubContext.Clients.All.broadcastDashboardMessage(msg);
            hubContext.
            return msg;

        }

    }
}