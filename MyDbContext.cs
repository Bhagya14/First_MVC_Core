using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace First_MVC_Core.Models
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> opt) : base(opt) { }
        public DbSet<EmployeeModel> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeModel>().ToTable("tbl_employees");
            modelBuilder.Entity<EmployeeModel>().HasKey(p => p.EmployeeID);
            modelBuilder.Entity<EmployeeModel>().Property(p => p.EmployeeID).UseSqlServerIdentityColumn();
            modelBuilder.Entity<EmployeeModel>().Property(p => p.EmployeeName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<EmployeeModel>().Property(p => p.EmployeePassword).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<EmployeeModel>().Property(p => p.EmployeeeCity).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<EmployeeModel>().Property(p => p.EmployeeDoj).IsRequired().HasDefaultValueSql("getdate()");

        }
    }
}
