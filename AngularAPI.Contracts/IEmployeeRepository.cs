using System.Collections.Generic;
using System.Threading.Tasks;
using AngularAPI.Entities.RelatedModels;
using AngularAPI.Entities.Models;
using System;

namespace AngularAPI.Contracts
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        Task<IEnumerable<Employee>> GetAllAsyncData();
        Task<Employee> GetByIDAsyncData(int employeeID);
        Task<EmployeeRelated> GetByIDRelatedAsyncData(int employeeID);
        Task PostCreateAsyncData(Employee employee);
        Task PutUpdateAsyncData(Employee dbEmployee, Employee employee);
        Task DeleteByIDAsyncData(Employee employee);
        bool GetByIDAsyncData(Func<object, bool> p);
    }
}
