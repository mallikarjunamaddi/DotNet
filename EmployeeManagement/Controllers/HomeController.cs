using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
	public class HomeController : Controller
	{
		private IEmployeeRepository _employeeRepository;

		//Constructor Injection
		public HomeController(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}
		public string Index()
		{
			return _employeeRepository.GetEmployee(1).Name;
		}

		public ViewResult Details()
		{
			var employeeModel = _employeeRepository.GetEmployee(1);
			ViewBag.PageTitle = "Employee Details:";
			return View(employeeModel);
		}
	}
}
