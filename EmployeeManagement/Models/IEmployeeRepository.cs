using System.Collections;

namespace EmployeeManagement.Models
{
	public interface IEmployeeRepository
	{
		Employee GetEmployee(int id);
		IEnumerable GetAllEmployees();
	}
}
