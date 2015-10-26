using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proj.Models.Twilio
{
    public class SmsInbound
    {
		string MessageSid
		{
			get; set;
		}
		string SmsSid
		{
			get; set;
		}
		string AccountSid
		{
			get; set;
		}
		string From
		{
			get; set;
		}
		string To
		{
			get; set;
		}
		string Body
		{
			get; set;
		}
		string NumMedia
		{
			get; set;
		}
}
