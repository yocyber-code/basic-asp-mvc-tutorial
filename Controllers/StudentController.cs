using BasicASPTutorial.Data;
using BasicASPTutorial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicASPTutorial.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _db;

        public StudentController(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Student> students = await _db.Student.ToListAsync();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }

            _db.Student.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var student = await _db.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }
            var student = await _db.Student.FindAsync(obj.Id);
            if (student == null)
            {
                return NotFound();
            }
            student.Name = obj.Name;
            student.Score = obj.Score;

            _db.Student.Update(student);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _db.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _db.Student.Remove(student);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
