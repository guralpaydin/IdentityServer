using Employee.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee.Helpers
{
    public class DataContext : DbContext
    {
        public DbSet<EmployeeEntity> Employees { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
