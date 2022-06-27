using Microsoft.EntityFrameworkCore;

namespace EmployeesManagmentApi.Entities
{
    public class EmployeesManagmentDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EmployeesManagmentDb;Trusted_Connection=True;");
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

          
            modelBuilder.Entity<Employee>()
                .Property(r => r.LastName)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<Employee>()
                .Property(r => r.Age)
                .IsRequired()
                .HasMaxLength(3);

            modelBuilder.Entity<Employee>()
                .Property(r => r.ContactNumber)
                .IsRequired()
                .HasMaxLength(9);

            modelBuilder.Entity<Department>()
               .Property(r => r.Name)
               .IsRequired()
               .HasMaxLength(64);

            //modelBuilder.Entity<Department>()
            //    .HasOne(a => a.Allocation)
            //    .WithOne(d => d.Department)
            //    .HasForeignKey<Allocation>(a => a.DepartmentId);

            
        }
    }
}
