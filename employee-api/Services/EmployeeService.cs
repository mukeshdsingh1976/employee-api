using EmployeeManagementAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementAPI.Services
{
    public class EmployeeService
    {
        private readonly List<Employee> _employees = new();

        public EmployeeService()
        {
            // Seed data
            _employees.AddRange(new[]
            {
                new Employee { Id = 1, Name = "Alice", Position = "Developer", Salary = 60000 },
                new Employee { Id = 2, Name = "Bob", Position = "Manager", Salary = 80000 }
            });
        }

        public List<Employee> GetAll() => _employees;

        public Employee GetById(int id) => _employees.FirstOrDefault(e => e.Id == id);

        public Employee GetByName(string name) => _employees.FirstOrDefault(e => e.Name.Contains(name));

        public void Add(Employee employee)
        {
            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            var existing = GetById(employee.Id);
            if (existing != null)
            {
                existing.Name = employee.Name;
                existing.Position = employee.Position;
                existing.Salary = employee.Salary;
            }
        }

		public void Delete(int id) => _employees.RemoveAll(e => e.Id == id);

    }
}
