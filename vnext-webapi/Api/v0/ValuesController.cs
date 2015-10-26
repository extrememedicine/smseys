using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using proj.Models;

namespace proj.Api.v0
{
    [Route("api/v0/[controller]")]
    public class ValuesController : Controller
    {
		// GET: api/values
		[HttpGet]
		public List<Victim> Get()
		{
			return Repositories.VictimRepository.GetAll();
		}
    }
}
