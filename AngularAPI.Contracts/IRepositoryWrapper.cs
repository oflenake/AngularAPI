using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AngularAPI.Contracts
{
    public interface IRepositoryWrapper
    {
        IEmployeeRepository EmployeeRepository { get; }
        IBankAccountRepository BankAccountRepository { get; }
    }
}
