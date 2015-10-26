using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace proj.Models
{
	public class VictimTools
	{
		public Victim VictimDecode(string encoded) //pretend i'm a gzip
		{
			var stage = System.Convert.FromBase64String(encoded);
			var plain = System.Text.Encoding.UTF8.GetString(stage);
			var decoded = JsonConvert.DeserializeObject<Victim>(plain);
			return decoded;
		}
		public string VictimEncode(Victim victim)
		{
			var plain = JsonConvert.SerializeObject(victim);
			var bytes = System.Text.Encoding.UTF8.GetBytes(plain);
			var encoded = System.Convert.ToBase64String(bytes);
			return encoded;
		}
	}

	public class Victim
	{
		public string Location { get; set; }
		public string Name { get; set; }
		public string Age { get; set; }
		public string Gender { get; set; }
		public UrgencyLevel UrgencyLevel {get; set;} 
		public bool HaveFood { get; set; }
		public bool HaveWater {	get; set; }
		public bool HaveExistingMedication { get; set; }
		public BleedingLevel BleedingLevel	{ get; set; }

	}
	public enum UrgencyLevel
	{
		P1Immediate, P2WaitHour, P3WaitFour
	}
	public enum BleedingLevel
	{
		Internal, ExternalCore, ExternalExtremities, Minor
	}
}
