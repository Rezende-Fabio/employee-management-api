using System.ComponentModel.DataAnnotations;
using employee_management_api.Enums;

namespace employee_management_api.Dtos;

public class UpdateEmployeeDto
{   
    [Required]
    [MaxLength(65)]
    public string NomeCompleto { get; set; }

    [Required]
    public DepartmentsEnum Departamento { get; set; }

    [Required]
    public ShiftsEnum Turno { get; set; }
}