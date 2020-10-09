using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
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
			//Adding MVC Service to Dependency Injection Container.
			services.AddMvc(mvcOptions => mvcOptions.EnableEndpointRouting = false);

			//Adding MockEmployeeRepository to Dependency Injection Container.
			services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStaticFiles();

			//Including MVC in the pipeline.
			//app.UseMvcWithDefaultRoute();

			//Conventional Routing
			app.UseMvc( routes =>
			{
				routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
