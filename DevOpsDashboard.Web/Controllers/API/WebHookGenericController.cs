﻿using DevOpsDashboard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DevOpsDashboard.Web.Controllers.API
{
    public class WebHookGenericController : ApiController
    {
        

        // POST api/<controller>
        [Route("api/webhook/generic")]
        public DashboardMessageGeneric Post([FromBody]DashboardMessageGeneric msg)
        {
            return msg;
        }
        /*
        [HttpPost]
       [Route("api/webhook/generic/json")]
        public async Task PostRawBufferManual()
        {
            string RawJSON = await Request.Content.ReadAsStringAsync();
            DashboardMessageGeneric msg=DashboardMessageGeneric.CreateFromJson(RawJSON);
            
        }
   */
    }
}