using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using AngularAPI.Entities.Models;

namespace AngularAPI.Entities
{
    /// <summary>
    /// The <see cref="RepositoryContext"/> class is the main generic <see cref="DbContext"/> 
    /// (EmployeeContext) class, that facilitates the <see cref="Employee"/> entity's 
    /// data and it's related data manipulations. It also facilitates the 
    /// <see cref="BankAccount"/> entity's data and it's related data manipulations.
    /// </summary>
    public class RepositoryContext : DbContext
    {
        #region Fields
        private string _component;
        private string _process;
        private string _message;
        #endregion

        #region Constructor
        /// <summary>
        /// Inject the logger and repository parameter services inside the constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="repowrap"></param>
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }
        #endregion

        public DbSet<Employee> EmployeeEntity { get; set; }
        public DbSet<BankAccount> BankAccountEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employee>().HasData(
            //    new Employee() { Fname = "Mangesh", Lname = "G", email = "Mangesh.g@outlook.com", gender = "1" },
            //    new Employee() { Fname = "Ramnath", Lname = "Bodke", email = "Ramnagh.g@outlook.com", gender = "1" },
            //    new Employee() { Fname = "Suraj", Lname = "G", email = "suraj.g@gmail.com", gender = "1" },
            //    new Employee() { Fname = "Jaffar", Lname = "K", email = "Jaffar.g@outlook.com", gender = "1" }
            //    );
        }
    }
}
