using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
	public class EmployeeManagementDbContext : DbContext
	{
		public EmployeeManagementDbContext(DbContextOptions<EmployeeManagementDbContext> options) : base(options)
		{

		}

		public DbSet<Employee> Employees { get; set; } 
	}
}
