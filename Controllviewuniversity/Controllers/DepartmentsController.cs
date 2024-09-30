using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly SchoolContext _context;

        public DepartmentsController(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Departments.Include(department => department.Administrator);
            return View(await schoolContext.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string query = "SELECT * FROM Departments WHERE DepartmentID = {0}"; //Kui ei oska C# siis on ka võimalik andmebaasi päringutes teha ehk SQL

            var department = await _context.Departments
               .FromSqlRaw(query, id)
               .Include(d => d.Administrator)
               .AsNoTracking()
               .FirstOrDefaultAsync();
            if (department == null)
            {
                return NotFound();
            }
            return View(department);

        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Budget,StarDate,RowVersion,InstructorID,Cigarettes,DarkLord")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }

            ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName", department.InstructorID);
            return View(department);
        }

        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }


            var department = await _context.Departments
                .Include(d => d.Administrator)
                .FirstOrDefaultAsync(d => d.DepartmentID == id);


            if (department == null)
            {
                return NotFound();
            }

            ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName", department.InstructorID);
            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var department = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Name,Budget,StarDate,RowVersion,InstructorID,Cigarettes,DarkLord")] Department department)
        {

            if (ModelState.IsValid)
            {
                _context.Update(department);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName", department.InstructorID);
            return View(department);



        }


        public async Task<IActionResult> BaseOn(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.DepartmentID == id);
            if (department == null)
            {
                return NotFound();
            }


            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BaseOn(Department department, string action)
        {
            if (ModelState.IsValid)
            {
 
                var newDepartment = new Department
                {
                    Name = department.Name,
                    Budget = department.Budget,
                    StarDate = department.StarDate,
                    DarkLord = department.DarkLord,
                    Cigarettes = department.Cigarettes,
                    InstructorID = department.InstructorID
                };

                _context.Add(newDepartment);
                await _context.SaveChangesAsync();


                if (action == "MakeAndDeleteOld")
                {
                    var oldDepartment = await _context.Departments.FindAsync(department.DepartmentID);
                    if (oldDepartment != null)
                    {
                        _context.Departments.Remove(oldDepartment);
                        await _context.SaveChangesAsync();
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }
    }
}



