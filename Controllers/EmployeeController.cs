using employee_management_api.Dtos;
using employee_management_api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace employee_management_api.Controllers;

[ApiController]
[Route("v1/employees")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeCrud _employeeService;
    public EmployeeController(IEmployeeCrud interfaceEmployeeService)
    {
        _employeeService = interfaceEmployeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        try
        {
            var respService = await _employeeService.GetAllEmployees();
            return Ok(respService);
        }
        catch (Exception)
        {
            return Problem(
                    statusCode: 500,
                    title: "Server Error"
                );
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetEmployeeById([FromRoute] int id)
    {
        try
        {
            var respService = await _employeeService.GetEmployeeById(id);
            return Ok(respService);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception)
        {
            return Problem(
                    statusCode: 500,
                    title: "Server Error"
                );
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto employee)
    {
        try
        {
            if (!ModelState.IsValid)
                BadRequest();
            
            var respService = await _employeeService.CreateEmployee(employee);
            return Created($"v1/employees/{respService.EmployeeEntityId}", respService);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return Problem(
                    statusCode: 500,
                    title: "Server Error"
                );
        }
    }

}