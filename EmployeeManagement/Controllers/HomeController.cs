using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
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
		public ViewResult Index()
		{
			return View(_employeeRepository.GetAllEmployees());
		}

		public ViewResult Details()
		{
			//We create a ViewModel when the model object
			//doesn't contain all the data a view needs.
			HomeDetailsViewModel detailsViewModel = new HomeDetailsViewModel()
			{
				Employee = _employeeRepository.GetEmployee(1),
				PageTitle = "Employee Details:"
			};
			return View(detailsViewModel);
		}
	}
}
