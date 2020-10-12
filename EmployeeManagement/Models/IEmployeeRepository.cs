using System.Collections;

namespace EmployeeManagement.Models
{
	public interface IEmployeeRepository
	{
		Employee GetEmployee(int id);
		IEnumerable GetAllEmployees();
		Employee AddEmployee(Employee employee);
		Employee UpdateEmployee(Employee employeeChanges);
		Employee DeleteEmployee(int id);
	}
}
