using System.Collections.Generic;
using System.Threading.Tasks;
using AngularAPI.Entities.Models;

namespace AngularAPI.Contracts
{
    public interface IBankAccountRepository : IRepositoryBase<BankAccount>
    {
        Task<IEnumerable<BankAccount>> GetAllAsyncData();
        //Task<BankAccount> GetByIDAsyncData(int bankaccountNO);
        //Task<BankAccount> GetByIDRelatedAsyncData(int employeeID);      // Get Employee's related BankAccounts
    }
}
