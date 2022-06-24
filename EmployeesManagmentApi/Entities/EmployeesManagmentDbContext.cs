using Microsoft.EntityFrameworkCore;

namespace EmployeesManagmentApi.Entities
{
    public class EmployeesManagmentDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Datebase=RestaurantDb;Trusted_Connection=True;");
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Allocation> Allocations { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(r => r.FirstName)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<Department>()
               .Property(r => r.Name)
               .IsRequired()
               .HasMaxLength(64);
            modelBuilder.Entity<Allocation>()
                .HasOne(d => d.Department)
                .WithOne(a => a.Allocation)
                .HasForeignKey<Department>(d => d.AllocationId);
        }
    }
}
