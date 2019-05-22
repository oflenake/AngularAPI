using AngularAPI.Entities.Models;

namespace AngularAPI.Entities.Extensions
{
    /// <summary>
    /// The static <see cref="EmployeeExtensions"/>, extension class helps to map <see cref="Map"/> 
    /// the same two <see cref="Employee"/> object entities to each other, for further processing.
    /// </summary>
    public static class EmployeeExtensions
    {
        public static void Map(this Employee dbEmployee, Employee employee)
        {
            dbEmployee.Fname = employee.Fname;
            dbEmployee.Lname = employee.Lname;
            dbEmployee.email = employee.email;
            dbEmployee.gender = employee.gender;
        }
    }
}
