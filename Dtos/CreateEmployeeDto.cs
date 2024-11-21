using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using employee_management_api.Enums;

namespace employee_management_api.Dtos;

public class CreateEmployeeDto
{   
    [Required]
    [MaxLength(65)]
    public string NomeCompleto { get; set; }

    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DepartmentsEnum Departamento { get; set; }

    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ShiftsEnum Turno { get; set; }
}