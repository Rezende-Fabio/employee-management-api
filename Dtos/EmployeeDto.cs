using employee_management_api.Enums;
using employee_management_api.Models;

namespace employee_management_api.Dtos;

public class EmployeeDto
{
    public EmployeeDto(EmployeeEntity employee)
    {
        Id = employee.EmployeeEntityId;
        NomeCompleto = employee.NomeCompleto;
        Departamento = employee.Departamento;
        Turno = employee.Turno;
    }

    public int Id { get; set; }

    public string NomeCompleto { get; set; }

    public DepartmentsEnum Departamento { get; set; }

    public ShiftsEnum Turno { get; set; }
}