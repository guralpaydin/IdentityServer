using Employee.Entities;
using Employee.Model;
using System.Collections.Generic;

namespace Employee.Services
{
    public interface IEmployeeService
    {
        List<EmployeeEntity> GetEmployees();
        EmployeeResponse GetEmployee(int id);
        EmployeeResponse CreateEmployee(EmployeeRequest model);
        EmployeeResponse UpdateEmployee(int id, EmployeeUpdateRequest model);
    }
}
