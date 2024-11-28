using DiPatternDemo.Models;

namespace DiPatternDemo.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentById(int id);
        public int AddStudent(Student student);
        public int UpdateStudent(Student student);
        public int DeleteStudent(int id);
    }
}
