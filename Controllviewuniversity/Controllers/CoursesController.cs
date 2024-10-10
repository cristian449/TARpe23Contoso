using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchoolContext _context;

        public CoursesController(SchoolContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Courses;
            return View(await schoolContext.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (course == null) {return NotFound();}

            ViewData["Action"] = "Details";
            return View("DetailsDelete", course); 
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) { return NotFound(); }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.CourseID == id);
           
            if (course == null) {return NotFound();}

            ViewData["Action"] = "Delete";
            return View("DetailsDelete", course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View("CreateEdit", new Course());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseID,Title,Credits")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("CreateEdit", course); // Specify the shared view
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) // Fix: should be id instead of CourseID
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id); // Fix: should be Courses instead of Course
            if (course == null)
            {
                return NotFound();
            }
            return View("CreateEdit", course); // Specify the shared view
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseID,Title,Credits")] Course course)
        {
            if (id != course.CourseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            if (!CourseExists(course.CourseID)) // Fix: should check CourseID, not ID
            {
                return NotFound();
            }

            return View("CreateEdit", course); // Specify the shared view
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseID == id); 
        }
    }
}