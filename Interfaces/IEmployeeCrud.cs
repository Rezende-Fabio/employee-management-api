using employee_management_api.Models;

namespace employee_management_api.Interfaces;

public interface IEmployeeCrud{
    Task<List<EmployeeEntity>> GetAllEmployees();
    Task<EmployeeEntity> GetEmployeeById(int id);
}