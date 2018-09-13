using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DevOpsDashboard.Models;


namespace DevOpsDashboard.Web.Controllers.API
{
    [ApiController]
    public class WebHookGenericController : ControllerBase
    {
        

        // POST api/<controller>
        [HttpPost]
        [Route("api/webhook/generic")]
        public DashboardMessageGeneric Post([FromBody]DashboardMessageGeneric msg)
        {
            //var hubContext = GlobalHost.ConnectionManager.GetHubContext<DashboardMessageHub>();
            //hubContext.Clients.All.broadcastDashboardMessage(msg);
            //DashboardMessageCache.Add(msg);
            return msg;
        }
       
    }
}