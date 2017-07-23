using DevOpsDashboard.Model;
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

            return msg;

        }

    }
}