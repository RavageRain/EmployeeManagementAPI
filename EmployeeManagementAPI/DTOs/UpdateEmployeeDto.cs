using System.ComponentModel.DataAnnotations;
namespace EmployeeManagementAPI.DTOs
{
    public class UpdateEmployeeDto
    {
        [Required]
        public string Position { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }
    }
}
