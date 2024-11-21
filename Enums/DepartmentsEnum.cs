using System.Text.Json.Serialization;

namespace employee_management_api.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DepartmentsEnum
{
    RH,
    TI,
    COMPRAS,
    ATENDIMENTO,
    FINANCEIRO,
    COMERCIAL,
    PRODUCAO,
}