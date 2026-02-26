using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.DTOs;
using EmployeeManagementAPI.Models;
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
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet] 
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeFromId(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(empId => empId.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(CreateEmployeeDto newEmployeeDto)
        {
            if (!ModelState.IsValid)// not needed because of ApiController. It does it automatically
            {
                return BadRequest(ModelState);
            }

            var newEmployee = new Employee
            {
                Name = newEmployeeDto.Name,
                Position = newEmployeeDto.Position,
                Salary = newEmployeeDto.Salary
            };
            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployeeFromId), new {id =  newEmployee.Id}, newEmployee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, UpdateEmployeeDto updatedEmployeeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await _context.Employees.FirstOrDefaultAsync(empId => empId.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            employee.Position = updatedEmployeeDto.Position;
            employee.Salary = updatedEmployeeDto.Salary;

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(empId => empId.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}