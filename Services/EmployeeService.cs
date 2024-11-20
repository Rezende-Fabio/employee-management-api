using employee_management_api.Context;
using employee_management_api.Dtos;
using employee_management_api.Enums;
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
            throw new KeyNotFoundException($"Employee id {id} was not found");

        return employee;
    }

    async Task<EmployeeEntity> IEmployeeCrud.CreateEmployee(CreateEmployeeDto createEmployee)
    {
        if (!Enum.IsDefined(typeof(DepartmentsEnum), createEmployee.Departamento)) //Caso o índice do departamento informado não seja válido
            throw new ArgumentException($"The provided department '{createEmployee.Departamento}' is invalid. " +
                                        "It must be one of the following: RH, TI, COMPRAS, ATENDIMENTO, FINANCEIRO, COMERCIAL and PRODUCAO.");

        if (!Enum.IsDefined(typeof(ShiftsEnum), createEmployee.Turno))
            throw new ArgumentException($"The provided shift '{createEmployee.Turno}' is invalid. " +
                                        "It must be one of the following: INTEGRAL, MANHA, TARDE and NOITE.");

        var employee = new EmployeeEntity
        {
            NomeCompleto = createEmployee.NomeCompleto,
            Departamento = createEmployee.Departamento,
            Turno = createEmployee.Turno
        };

        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();

        return employee;
    }
}