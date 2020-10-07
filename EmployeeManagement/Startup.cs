using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement
{
	public class Startup
	{
		private readonly IConfiguration _config;

		public Startup(IConfiguration config)
		{
			_config = config;
		}
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();
			app.Use(async (context, next) =>
			{
				 logger.LogInformation("MW1: Incomming Request");
				 await next();
				 logger.LogInformation("MW1: Outgoing response");
			});

			app.Use(async (context, next) =>
			{
				logger.LogInformation("MW2: Incomming Request");
				await next();
				logger.LogInformation("MW2: Outgoing response");
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGet("/", async context =>
				{
					var process = _config["Key"];
					await context.Response.WriteAsync(process);
					logger.LogInformation("MW3: Incomming Request handled");

				});
			});
			
		}
	}
}
