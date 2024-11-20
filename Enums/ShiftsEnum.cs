using System.Text.Json.Serialization;

namespace employee_management_api.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ShiftsEnum
{
    INTEGRAL,
    MANHA,
    TARDE,
    NOITE,
}