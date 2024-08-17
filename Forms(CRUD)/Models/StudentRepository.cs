
using Microsoft.EntityFrameworkCore;

namespace Forms_CRUD_.Models
{
    public class StudentRepository : StudentInterface
    {
        private  List<StudentModel> _student;
        public StudentRepository()
        {
            _student = new List<StudentModel>()
            {
                new StudentModel() {Id= 1, Name="Sammy", Description= " I am sammy", Email="Sammy12@gmail.com"},
                new StudentModel() {Id= 2, Name= "Alex", Description= "I am Alex", Email="Alex32@gmail.com"},
                new StudentModel() {Id=3, Name="Rayen", Description="I am Rayen", Email="Rayen21@gmail.com"}
            };
        }

        public StudentModel AddStudent(StudentModel student)
        {
            student.Id = _student.Max(x => x.Id)+1;
           _student.Add(student);
            return student;
        }
        public StudentModel DeleteById(int id)
        {
            StudentModel student = _student.FirstOrDefault(x => x.Id == id);
            if (student != null)
            {
                _student.Remove(student);
                
                //_student.SaveChanges(); 
            }
            return student;
        }

        public StudentModel GetStudentById(int id)
        {
            return _student.FirstOrDefault(e => e.Id == id);
        }


        public IEnumerable<StudentModel> GetAllStudent()
        {
            return _student;
        }

       

        public StudentModel UpdateStudent(StudentModel Updatedstudent)
        {
           StudentModel student= _student.FirstOrDefault(x => x.Id == Updatedstudent.Id);
            if(Updatedstudent!= null)
            {
                Updatedstudent.Name= Updatedstudent.Name;
                Updatedstudent.Email= Updatedstudent.Email;
                Updatedstudent.Description= Updatedstudent.Description;
               
            }
            return student;

        }
    }
}
