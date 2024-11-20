using employee_management_api.Models;
using Microsoft.EntityFrameworkCore;

namespace employee_management_api.Context; 

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<EmployeeEntity> Employees { get; set; }

}