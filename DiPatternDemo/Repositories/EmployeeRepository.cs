using DiPatternDemo.Data;
using DiPatternDemo.Models;

namespace DiPatternDemo.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext db;

        public EmployeeRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddEmployee(Employee employee)
        {
            int result = 0;
            db.Employees?.Add(employee);
            result =  db.SaveChanges();
            return result;
        }

        public int DeleteEmployee(int id)
        {
            int result = 0;
            var emp = db.Employees?.Where(x=>x.empid == id).SingleOrDefault();
            if(emp != null)
            {
                db.Employees?.Remove(emp);
                result = db.SaveChanges() ;
            }
            return result;
        }


        public IEnumerable<Employee> GetEmployee()
        {
            return db.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return db.Employees?.Where(x => x.empid == id).SingleOrDefault();
        }

        public int UpdateEmployee(Employee employee)
        {
            int result = 0;
            var emp = db.Employees?.Where(x => x.empid == employee.empid).SingleOrDefault();
            if(emp != null)
            {
                emp.name = employee.name;
                emp.email = employee.email;
                emp.salary = employee.salary;
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
