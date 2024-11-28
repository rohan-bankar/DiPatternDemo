using DiPatternDemo.Models;
using DiPatternDemo.Repositories;

namespace DiPatternDemo.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository repo;

        public EmployeeService(IEmployeeRepository repo)
        {
            this.repo = repo;
        }

        public int AddEmployee(Employee employee)
        {
            return repo.AddEmployee(employee);
        }

        public int DeleteEmployee(int id)
        {
            return repo.DeleteEmployee(id);
        }

        public IEnumerable<Employee> GetEmployee()
        {
            return repo.GetEmployee();
        }

        public Employee GetEmployeeById(int id)
        {
            return repo.GetEmployeeById(id);
        }

        public int UpdateEmployee(Employee employee)
        {
            return repo.UpdateEmployee(employee);
        }
    }
}
