using Microsoft.EntityFrameworkCore;
using System.Data.Common;


namespace ManagementSystem.Models
{
    public class EntityContext:DbContext
    {
        public EntityContext():base() { }

        public EntityContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set;}
        public DbSet<Branch>Branches { get; set;}   
        public DbSet<Department>departments { get; set;}   
        public DbSet<Employee_User>users { get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
