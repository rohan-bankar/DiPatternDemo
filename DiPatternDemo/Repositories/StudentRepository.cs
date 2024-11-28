using DiPatternDemo.Data;
using DiPatternDemo.Models;

namespace DiPatternDemo.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext db;
        public StudentRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddStudent(Student student)
        {
            int result = 0;
            db.Students?.Add(student);
            result = db.SaveChanges();
            return result;
        }

        public int DeleteStudent(int id)
        {
            int result = 0;
            var emp = db.Students?.Where(x=>x.Studid == id).FirstOrDefault();
            if(emp != null)
            {
                db.Students?.Remove(emp);
            }
            result = db.SaveChanges();
            return result;
        }

        public Student GetStudentById(int id)
        {
            return db.Students?.Where(x => x.Studid == id).SingleOrDefault();
        }

        public IEnumerable<Student> GetStudents()
        {
            return db.Students?.ToList();
        }

        public int UpdateStudent(Student student)
        {
            int result = 0;
            var emp = db.Students?.Where(x => x.Studid == student.Studid).SingleOrDefault();
            if(emp != null)
            {
                emp.StudName = student.StudName;
                emp.StudDepartment = student.StudDepartment;
                emp.StudPercentage = student.StudPercentage;
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
