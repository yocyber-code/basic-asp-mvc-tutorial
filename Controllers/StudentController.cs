using BasicASPTutorial.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicASPTutorial.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            var student1 = new Student();
            student1.Id = 1;
            student1.Name = "John";
            student1.Score = 100;
            var student2 = new Student();
            student2.Id = 2;
            student2.Name = "Jame";
            student2.Score = 49;
            var student3 = new Student();
            student3.Id = 3;
            student3.Name = "Jane";
            student3.Score = 97;

            students.Add(student1);
            students.Add(student2);
            students.Add(student3);

            return View(students);
        }
        
        public IActionResult Create()
        {
            return View();
        }
    }
}
