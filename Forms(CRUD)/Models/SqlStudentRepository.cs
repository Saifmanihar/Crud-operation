
namespace Forms_CRUD_.Models
{
    public class SqlStudentRepository : StudentInterface
    {
        private readonly AppDb context;

        public SqlStudentRepository(AppDb context)
        {
            this.context= context;
        }

        public StudentModel AddStudent(StudentModel Addstudent)
        {
           context.Students.Add(Addstudent);
            context.SaveChanges();
            return Addstudent;
        }

        public StudentModel DeleteById(int id)
        {
            StudentModel student= context.Students.Find(id);
            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }
            return student;
        }

        public IEnumerable<StudentModel> GetAllStudent()
        {
            return  context.Students;
        }

        public StudentModel GetStudentById(int id)
        {
            return context.Students.Find(id);
        }

        public StudentModel UpdateStudent(StudentModel studentChanges)
        {
           var students = context.Students.Attach(studentChanges); 
            students.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return studentChanges;
        }
    }
}
