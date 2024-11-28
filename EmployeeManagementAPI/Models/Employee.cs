namespace EmployeeManagementAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; } // Nullable
        public string? Position { get; set; } // Nullable
        public decimal Salary { get; set; } = 0;
    }
}