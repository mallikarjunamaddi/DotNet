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
		public Employee GetEmployee(int id)
		{
			return _employeeList.FirstOrDefault( e => e.Id == id);
		}
	}
}
