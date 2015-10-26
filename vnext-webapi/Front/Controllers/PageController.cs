using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace proj.Front.controller
{
	public class PageController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
			return View("Index", Repositories.VictimRepository.GetAll());
        }
		public IActionResult Dash()
		{
			return View("Dash", Repositories.VictimRepository.GetAll());
		}
    }
}
