using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DevOpsDashboard.Models;
using System.Threading.Tasks;
using System.IO;

namespace DevOpsDashboard.Web.Controllers.API
{
    [ApiController]
    public class WebHookGitHubController : ControllerBase
    {

        [HttpPost]
        [Route("api/webhook/github")]
        public async Task<DashboardMessageGitHub> PostRawBufferManual()
        {
            
            IEnumerable<string> headerValues = Request.Headers["X-GitHub-Event"];
            string GitHubEvent = headerValues.FirstOrDefault();

            StreamReader sr=new StreamReader(Request.Body);
            string RawJSON="";
            while (!sr.EndOfStream)
            {
                RawJSON+=await sr.ReadLineAsync();
            }
            DashboardMessageGitHub msg = new DashboardMessageGitHub(RawJSON, GitHubEvent);

            //var hubContext = GlobalHost.ConnectionManager.GetHubContext<DashboardMessageHub>();
            //hubContext.Clients.All.broadcastDashboardMessage(msg);
            //DashboardMessageCache.Add(msg);
            return msg;

        }

    }
}