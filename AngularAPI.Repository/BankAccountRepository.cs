using AngularAPI.Contracts;
using AngularAPI.Entities;
using AngularAPI.Entities.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AngularAPI.Repository
{
    /// <summary>
    /// The <see cref="BankAccountRepository"/> class that access the base repository backend through 
    /// the <see cref="RepositoryWrapper"/> class, to manipulate the <see cref="BankAccount"/> 
    /// entity data and its related data.
    /// </summary>
    public class BankAccountRepository : RepositoryBase<BankAccount>, IBankAccountRepository
    {
        public BankAccountRepository(ILoggerManager logger, RepositoryContext repositoryContext)
            : base(logger, repositoryContext)
        {
        }

        // Get all BankAccounts
        public async Task<IEnumerable<BankAccount>> GetAllAsyncData()
        {
            return await GetAllBaseData()
                .OrderBy(b => b.AccountName)
                .ToListAsync();
        }

        //public async Task<BankAccount> GetByIDAsyncData(int bankaccountNO)
        //{
        //    return await GetByIDBaseData(a => a.BankAccountNumber.Equals(bankaccountNO))
        //        .Select(employee => new Employee(employee)
        //        {
        //            BankAccounts = RepositoryContext.BankAccountEntity
        //            .Where(ba => ba.UserID.Equals(employee.UserID))
        //            .ToList()
        //        })
        //        .SingleOrDefaultAsync();
        //}

        //// Get all related BankAccounts for a particular Employee
        //public async Task<BankAccount> GetByIDRelatedAsyncData(int employeeID)
        //{
        //    return await GetByIDBaseData(o => o.UserID.Equals(employeeID))
        //        .Select(employee => new EmployeeRelated(employee)
        //        {
        //            BankAccounts = RepositoryContext.BankAccountEntity
        //            .Where(a => a.ClientNumber.Equals(employee.UserID))
        //            .ToList()
        //        })
        //        .SingleOrDefaultAsync();
        //}
    }
}
