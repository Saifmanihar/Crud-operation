using Forms_CRUD_.Models;
using Forms_CRUD_.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace Forms_CRUD_.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly StudentInterface _studentInterface; 
        //private readonly IHostEnvironment hostingEnvironment;
        private readonly IWebHostEnvironment hostingEnvironment;

        public HomeController(StudentInterface studentInterface , IWebHostEnvironment hostingEnvironment)
        {
            _studentInterface = studentInterface;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Controller will Post  the data of  form to database
        [HttpPost]
        public IActionResult Index(StudentCreateViewModel std)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploaderfile(std);
                StudentModel newStudent = new StudentModel
                {
                    Name = std.Name,
                    Email = std.Email,
                    Description = std.Description,
                    PhotoPath = uniqueFileName
                };
                _studentInterface.AddStudent(newStudent);
                return RedirectToAction("Privacy", new { id = newStudent.Id });
            }
            return View();
          
        }

        //Give the list of all the data
        public IActionResult StudentDetails()
        {
            var model = _studentInterface.GetAllStudent();
            return View(model);
        }

        [HttpPost]
        public IActionResult DeletebyId(int id)
        {
            StudentModel student = _studentInterface.DeleteById(id);
            return RedirectToAction("StudentDetails");
        }

        //Provide the particular data of the id which we want to see 
        public IActionResult Privacy(int? id)
        {
          
              StudentModel student = _studentInterface.GetStudentById(id.Value);
            if(student == null)
            {
                Response.StatusCode = 404;
                return View("StudentNotFound", id.Value);
            }
            //StudentModel student = _studentInterface.GetStudentById(id??5);
            return View(student);
        }

        //Edit Controller
        [HttpGet]
        public ViewResult Edit(int id)
        {
            StudentModel student = _studentInterface.GetStudentById(id);
            StudentEditViewModel studentEditViewModel = new StudentEditViewModel
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Description = student.Description,
                ExistingPhotoPath= student.PhotoPath
            };
            return View(studentEditViewModel);
        }


        //Post the updated data to database
        [HttpPost]
        public IActionResult Edit(StudentEditViewModel std)
        {
            if (ModelState.IsValid)
            {
                StudentModel student = _studentInterface.GetStudentById(std.Id);
                student.Name = std.Name;
                student.Email = std.Email;
                student.Description = std.Description;
               

                if (std.Photo != null)
                {
                    if(std.ExistingPhotoPath != null)
                    {
                       string FilePath= Path.Combine(hostingEnvironment.WebRootPath, "Images", std.ExistingPhotoPath);
                        System.IO.File.Delete(FilePath);
                    }
                    student.PhotoPath = ProcessUploaderfile(std);
                }
               

                _studentInterface.UpdateStudent(student);
                return RedirectToAction("StudentDetails");
            }
            return View();

        }

       
        private string ProcessUploaderfile(StudentCreateViewModel std)
        {
            string uniqueFileName = null;
            if (std.Photo != null)
            {
                foreach (IFormFile Photos in std.Photo)
                {
                    String uploadfolder = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + Photos.FileName;
                    string Filepath = Path.Combine(uploadfolder, uniqueFileName);
                    Photos.CopyTo(new FileStream(Filepath, FileMode.Create));
                    //using (var fileStream = new FileStream(Filepath, FileMode.Create))
                    //{
                    //    std.Photo.CopyTo(fileStream);
                    //}
                }

            }

            return uniqueFileName;
        }

     

        //Student List controller

        public IActionResult StudentList()
        {
            var StudentList = _studentInterface.GetAllStudent();
            return View(StudentList);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
