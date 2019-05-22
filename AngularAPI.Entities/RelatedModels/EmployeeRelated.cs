using AngularAPI.Entities.Models;
using System.Collections.Generic;

namespace AngularAPI.Entities.RelatedModels
{
    public class EmployeeRelated : IEntity
    {
        public int ID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string email { get; set; }
        public string gender { get; set; }

        public virtual IEnumerable<BankAccount> BankAccounts { get; set; }

        /// <see cref="EmployeeRelated"/> constructor enabled/disabled to configure lazy-loading.
        public EmployeeRelated(Employee employee)
        {
            ID = employee.ID;
            Fname = employee.Fname;
            Lname = employee.Lname;
            email = employee.email;
            gender = employee.gender;
        }
    }
}
