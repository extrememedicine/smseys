using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace proj.Api.v0
{
	[Route("api/v0/[controller]/[action]")]
	public class TwilioController
    {
		[HttpPost]
		//public object In(ILogger<TwilioController> logger, [FromBody]Models.Twilio.SmsInbound Inbound)
		public object In(Models.Twilio.SmsInbound inbound)
		{
			var content = inbound.Body;
			return new HttpStatusCodeResult(200);
        }
	}
}
