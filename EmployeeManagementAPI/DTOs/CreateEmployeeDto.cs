using System.ComponentModel.DataAnnotations;
namespace EmployeeManagementAPI.DTOs
{
    public class CreateEmployeeDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Position { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }
    }
}
