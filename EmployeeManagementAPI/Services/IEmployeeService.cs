using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee?> GetEmployeeFromIdAsync(int id);
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task<bool> UpdateEmployeeAsync(int id , Employee employee);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}