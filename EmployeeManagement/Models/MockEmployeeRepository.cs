using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Models
{
	public class MockEmployeeRepository : IEmployeeRepository
	{
		private IList<Employee> _employeeList;
		public MockEmployeeRepository()
		{
			_employeeList = new List<Employee>()
			{
				new Employee(){ Id=1, Name="Ram", Email="ram@gmail.com" },
				new Employee(){ Id=2, Name="Rosy", Email="rosy@gmail.com" },
				new Employee(){ Id=3, Name="Reia", Email="reia@gmail.com" }
			};
		}

		public Employee AddEmployee(Employee employee)
		{
			_employeeList.Add(employee);
			return employee;
		}

		public Employee DeleteEmployee(int id)
		{
			var employee = _employeeList.FirstOrDefault(e => e.Id == id);
			if (employee != null)
			{
				_employeeList.Remove(employee);
			}
			return employee;
		}

		public IEnumerable GetAllEmployees()
		{
			return _employeeList;
		}

		public Employee GetEmployee(int id)
		{
			return _employeeList.FirstOrDefault( e => e.Id == id);
		}

		public Employee UpdateEmployee(Employee employeeChanges)
		{
			var employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
			if (employee != null)
			{
				employee.Name = employeeChanges.Name;
				employee.Email = employeeChanges.Email;
			}
			return employee;
		}
	}
}
