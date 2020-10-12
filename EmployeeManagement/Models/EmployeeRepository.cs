using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private EmployeeManagementDbContext _dbContext;

		public EmployeeRepository(EmployeeManagementDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public Employee AddEmployee(Employee employee)
		{
			_dbContext.Employees.Add(employee);
			_dbContext.SaveChanges();
			return employee;
		}

		public Employee DeleteEmployee(int id)
		{
			var employee = _dbContext.Employees.Find(id);
			if (employee != null)
			{
				_dbContext.Employees.Remove(employee);
				_dbContext.SaveChanges();
			}
			return employee;
		}

		public IEnumerable GetAllEmployees()
		{
			return _dbContext.Employees;
		}

		public Employee GetEmployee(int id)
		{
			return _dbContext.Employees.Find(id);
		}

		public Employee UpdateEmployee(Employee employeeChanges)
		{
			var employee = _dbContext.Employees.Find(employeeChanges.Id);
			if (employee != null)
			{
				employee.Name = employeeChanges.Name;
				employee.Email = employeeChanges.Email;
				_dbContext.SaveChanges();
			}
			return employee;
		}
	}
}
