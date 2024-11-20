using System.ComponentModel.DataAnnotations;
using employee_management_api.Enums;

namespace employee_management_api.Models; 

public class EmployeeEntity {

    [Key]
    public int EmployeeEntityId { get; set; }

    [MaxLength(65)]
    public string NomeCompleto { get; set; }

    public DepartamentsEnum Departamento { get; set; }

    public ShiftsEnum Truno { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.Now.ToLocalTime();

    public DateTime DataAlteracao { get; set; } = DateTime.Now.ToLocalTime();

    public bool Delete { get; set; } = false;

}