using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.DTOs;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet] 
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            var employees = await _service.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeFromId(int id)
        {
            var employee = await _service.GetEmployeeFromIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto newEmployeeDto)
        {
            var newEmployee = new Employee
            {
                Name = newEmployeeDto.Name,
                Position = newEmployeeDto.Position,
                Salary = newEmployeeDto.Salary
            };

            var created = await _service.CreateEmployeeAsync(newEmployee);

            var response = new EmployeeDto
            {
                Id = created.Id,
                Name = created.Name,
                Position = created.Position,
                Salary = created.Salary

            }; 

            return CreatedAtAction(nameof(GetEmployeeFromId), new {id =  response.Id}, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeDto updatedEmployeeDto)
        {
            var employee = new Employee
            {
                Position = updatedEmployeeDto.Position,
                Salary = updatedEmployeeDto.Salary
            };

            var success = await _service.UpdateEmployeeAsync(id, employee);

            if (success == null)
            {
                return NotFound();
            }


            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _service.DeleteEmployeeAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}