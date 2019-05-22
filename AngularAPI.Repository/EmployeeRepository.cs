using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularAPI.Contracts;
using AngularAPI.Entities;
using AngularAPI.Entities.RelatedModels;
using AngularAPI.Entities.Extensions;
using AngularAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularAPI.Repository
{
    /// <summary>
    /// The <see cref="EmployeeRepository"/> class that access the base repository backend through 
    /// the <see cref="RepositoryWrapper"/> class, to manipulate the <see cref="Employee"/> 
    /// entity data and its related data.
    /// </summary>
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ILoggerManager logger, RepositoryContext repositoryContext)
            : base(logger, repositoryContext)
        {
        }

        // Get all Employees
        public async Task<IEnumerable<Employee>> GetAllAsyncData()
        {
            return await GetAllBaseData()
                .OrderBy(e => e.Lname)
                .ToListAsync();
        }

        // Get Employee by Id
        public async Task<Employee> GetByIDAsyncData(int employeeID)
        {
            return await GetByIDBaseData(o => o.ID.Equals(employeeID))
                    .DefaultIfEmpty(new Employee())
                    .SingleAsync();
        }

        // Get all related BankAccounts for a particular Employee
        public async Task<EmployeeRelated> GetByIDRelatedAsyncData(int employeeID)
        {
            return await GetByIDBaseData(o => o.ID.Equals(employeeID))
                .Select(employee => new EmployeeRelated(employee)
                {
                    BankAccounts = RepositoryContext.BankAccountEntity
                    .Where(a => a.ClientNumber.Equals(employee.ID))
                    .ToList()
                })
                .SingleOrDefaultAsync();
        }

        // Create new Employee
        public async Task PostCreateAsyncData(Employee employee)
        {
            int newID = 10;
            //employee.ID = Guid.NewGuid();
            employee.ID = newID;
            PostCreateBaseData(employee);
            await SaveAsyncBaseData();
        }

        // Update Employee
        public async Task PutUpdateAsyncData(Employee dbEmployee, Employee employee)
        {
            dbEmployee.Map(employee);
            PutUpdateBaseData(dbEmployee);
            await SaveAsyncBaseData();
        }

        // Delete Employee
        public async Task DeleteByIDAsyncData(Employee employee)
        {
            DeleteByIDBaseData(employee);
            await SaveAsyncBaseData();
        }

        public bool GetByIDAsyncData(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
