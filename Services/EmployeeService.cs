using employee_management_api.Context;
using employee_management_api.Interfaces;
using employee_management_api.Models;
using Microsoft.EntityFrameworkCore;

namespace employee_management_api.Services;

public class EmployeeService : IEmployeeCrud
{
    private readonly AppDbContext _context;
    public EmployeeService(AppDbContext context)
    {
        _context = context;
    }

    async Task<List<EmployeeEntity>> IEmployeeCrud.GetAllEmployees()
    {
        var employees = await _context.Employees.AsNoTracking().ToListAsync();
        return employees;
    }

    async Task<EmployeeEntity> IEmployeeCrud.GetEmployeeById(int id)
    {
        var employee = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.EmployeeEntityId == id);

        if (employee == null)
        {
            throw new KeyNotFoundException($"Employee id {id} was not found");
        }

        return employee;
    }
}