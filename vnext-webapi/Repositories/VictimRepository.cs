using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proj.Repositories
{
    public static class VictimRepository
    {
		private static List<Models.Victim> victims
		{
			get; set;
		}

		public static void Initial()
		{
			victims = new List<Models.Victim>();
		}
		public static void Add(Models.Victim victim) {
			victims.Add(victim);
		}
		public static List<Models.Victim> GetAll()
		{
			return victims;
		}
	}
}
