using System.ComponentModel.DataAnnotations;
namespace EmployeeManagementAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Position { get; set; } = string.Empty;
        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }

    }
}