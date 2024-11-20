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
                    title: "Erro interno do servidor"
                );
        }

    }

}