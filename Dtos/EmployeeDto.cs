using employee_management_api.Enums;
using employee_management_api.Models;

namespace employee_management_api.Dtos;

public class EmployeeDto
{
    public EmployeeDto(EmployeeEntity employee)
    {
        NomeCompleto = employee.NomeCompleto;
        Departamento = employee.Departamento;
        Turno = employee.Turno;
    }

    public string NomeCompleto { get; set; }

    public DepartmentsEnum Departamento { get; set; }

    public ShiftsEnum Turno { get; set; }
}