using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DevOpsDashboard.Models;
using System.Threading.Tasks;

namespace DevOpsDashboard.Web.Controllers.API
{
    [ApiController]
    public class WebHookGitHubController : ControllerBase
    {



        [HttpPost]
        [Route("api/webhook/github")]
        public async Task<DashboardMessageGitHub> PostRawBufferManual()
        {
            
            IEnumerable<string> headerValues = Request.Headers.GetValues("X-GitHub-Event");
            string GitHubEvent = headerValues.FirstOrDefault();

            string RawJSON = await Request.Content.ReadAsStringAsync();

            DashboardMessageGitHub msg = new DashboardMessageGitHub(RawJSON, GitHubEvent);

            //var hubContext = GlobalHost.ConnectionManager.GetHubContext<DashboardMessageHub>();
            //hubContext.Clients.All.broadcastDashboardMessage(msg);
            //DashboardMessageCache.Add(msg);
            return msg;

        }

    }
}