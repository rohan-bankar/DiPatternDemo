using DiPatternDemo.Models;

namespace DiPatternDemo.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployee();
        Employee GetEmployeeById(int id);
        int AddEmployee(Employee employee);
        int UpdateEmployee(Employee employee);
       
        int DeleteEmployee(int id);
    }
}
