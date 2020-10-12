using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
			//It registers our dbContext class with DI
			//when we use AddDbContextPool to register, it will check whether the dbcontext 
			//instance is already available in the pool, if availble it wont create a new
			//instance. so that it improves application performance.
			//Here we specify, the type of database provider and database connection string in the options.
			services.AddDbContextPool<EmployeeManagementDbContext>(options => 
			options.UseSqlServer(_config.GetConnectionString("EmployeeDB")));

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
