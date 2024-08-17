namespace Forms_CRUD_.Models
{
    public interface StudentInterface
    {
        StudentModel GetStudentById(int id);
        IEnumerable<StudentModel> GetAllStudent();

        StudentModel AddStudent(StudentModel student);

        StudentModel UpdateStudent(StudentModel student);
        StudentModel DeleteById(int id);
       
    }
}
