using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore_sample.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore_sample.Contexts
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 1, EmployeeName = "Harish", Skill = "Full Stack Developer", Email = "harish@mail.com", Salary = 70000 },
                new Employee() { Id = 2, EmployeeName = "Ram", Skill = "Oracle developer", Email = "Ram@mail.com", Salary = 80000 },
                new Employee() { Id = 3, EmployeeName = "Vicky", Skill = "Azure devops developer", Email = "vicky@mail.com", Salary = 90000 }
                );

            modelBuilder.Entity<Address>().HasData(
                new Address() { Id = 1, AddressDetail = "AddressDetail_1", EmployeeId = 1 },
                new Address() { Id = 2, AddressDetail = "AddressDetail_2", EmployeeId = 2 },
                new Address() { Id = 3, AddressDetail = "AddressDetail_3", EmployeeId = 3 }
                );
        }
    }
}
