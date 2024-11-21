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

    public async Task<List<EmployeeEntity>> GetAllEmployees()
    {
        var employees = await _context.Employees.AsNoTracking().ToListAsync();
        return employees;
    }

    public async Task<EmployeeEntity> GetEmployeeById(int id)
    {
        var employee = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.EmployeeEntityId == id);

        if (employee == null)
            throw new KeyNotFoundException($"Employee id {id} was not found");

        return employee;
    }

    public async Task<EmployeeEntity> CreateEmployee(CreateEmployeeDto createEmployee)
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

    public async Task<EmployeeEntity> UpdateEmployee(UpdateEmployeeDto updateEmployee, int id)
    {
        try
        {
            if (!Enum.IsDefined(typeof(DepartmentsEnum), updateEmployee.Departamento)) //Caso o índice do departamento informado não seja válido
                throw new ArgumentException($"The provided department '{updateEmployee.Departamento}' is invalid. " +
                                            "It must be one of the following: RH, TI, COMPRAS, ATENDIMENTO, FINANCEIRO, COMERCIAL and PRODUCAO.");

            if (!Enum.IsDefined(typeof(ShiftsEnum), updateEmployee.Turno))
                throw new ArgumentException($"The provided shift '{updateEmployee.Turno}' is invalid. " +
                                            "It must be one of the following: INTEGRAL, MANHA, TARDE and NOITE.");

            var employee = await GetEmployeeById(id);
            employee.NomeCompleto = updateEmployee.NomeCompleto;
            employee.Departamento = updateEmployee.Departamento;
            employee.Turno = updateEmployee.Turno;
            employee.DataAlteracao = DateTime.Now.ToLocalTime();

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

            return employee;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<EmployeeEntity> DeleteEmployee(int id)
    {
        try
        {
            var employee = await GetEmployeeById(id);
            employee.Delete = true;
            employee.DataAlteracao = DateTime.Now.ToLocalTime();

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

            return employee;
        }
        catch (Exception)
        {
            throw;
        }
    }
}