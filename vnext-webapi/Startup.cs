using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using Microsoft.Framework.Logging.Console;
using Newtonsoft.Json;

namespace proj
{
    public class Startup
    {
		public IConfiguration Configuration { get; set; }
		public Startup()
		{
			var configuration = new Configuration()
			  .AddJsonFile("config.json");
			//configuration.AddUserSecrets(); secrets-manager broken on nuget

			Repositories.VictimRepository.Initial();
			Repositories.VictimRepository.Add(new Models.Victim
			{
				Name = "Persistent Test User 1",
				Age = "23",
				Gender = Models.Gender.na,
				Location = "32.500215 : -5.129792",
				UrgencyLevel = Models.UrgencyLevel.P2WaitHour,
				HaveFood = true,
				HaveWater = false,
				HaveExistingMedication = false,
				BleedingLevel = Models.BleedingLevel.Minor
				
			});
			Repositories.VictimRepository.Add(new Models.Victim
			{
				Name = "Persistent Test User 2",
				Age = "12",
				Gender = Models.Gender.female,
				Location = "32.700215 : -5.829792",
				UrgencyLevel = Models.UrgencyLevel.P1Immediate,
				HaveFood = true,
				HaveWater = false,
				HaveExistingMedication = false,
				BleedingLevel = Models.BleedingLevel.ExternalCore

			});
			Repositories.VictimRepository.Add(new Models.Victim
			{
				Name = "Persistent Test User 3",
				Age = "19",
				Gender = Models.Gender.male,
				Location = "31.670215 : -4.629792",
				UrgencyLevel = Models.UrgencyLevel.P3WaitFour,
				HaveFood = false,
				HaveWater = true,
				HaveExistingMedication = false,
				BleedingLevel = Models.BleedingLevel.ExternalCore

			});

			Configuration = configuration;
		}
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddMvc().Configure<MvcOptions>(options =>
			{
				options.ViewEngines.Add(Type.GetType("proj.ViewEngines.DefaultViewEngine"));
			});
			services.AddLogging();

			Debug.WriteLine("Configured Services - " + Configuration["data:ConfigSanityCheck"]); // indentify config mis match
        }

		public void Configure(IApplicationBuilder app, ILoggerFactory LoggerFactory, ILogger<Startup> logger)
		{
			LoggerFactory.AddConsole(LogLevel.Information);

			app.Use(async (context, next) =>
			{
				var s = ("[Pipeline0] Request to:" + context.Request.Path);
				logger.LogInformation(s);
				await next();
			});

			app.UseStaticFiles();
			app.UseErrorPage();
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller}/{action}/{id?}",
					defaults: new { controller = "Page", action = "Index" });
			});
		}
    }
}
