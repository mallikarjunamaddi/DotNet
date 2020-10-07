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
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions()
				{
					//This indicates # of lines to be shown before and after the exception.
					SourceCodeLineCount = 5
				};
				app.UseDeveloperExceptionPage(developerExceptionPageOptions);
			}

			//This is a combination of UseDefacultFiles(), UseStaticFiles() and UseDirectoryFiles() middlewares
			//when the file is aviable it serves the file and short circuit (stops and reverse) the pipeline otherwise
			//it just pass on the request to next middleware
			app.UseFileServer();
			
			app.UseRouting();

			app.Run(async context =>
			{
					var process = _config["Key"];
					throw new Exception("Just to demo the Developer Exception Page.");
					await context.Response.WriteAsync(process);
			});

		}
	}
}
