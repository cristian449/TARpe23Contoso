﻿using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Controllers
{
    public class StudentsController : Controller
    {

        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context)
        {
            _context = context;
        }
        //get all for index, retrieve all students
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        /*

        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber
            )
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NamesortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSort"] = sortOrder == "Date" ? "date_desc" : "Date";


            if (searchString is null)
            {
                pageNumber = 1;
            }
            else 
            {
                searchString = currentFilter;
            }
            ViewData["currentFilter"] = searchString;

            var students = from student in _context.Students
                           select student;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(student =>
                student.LastName.Contains(searchString) ||
                student.FirstMidName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
               students = students.OrderByDescending(student => student.LastName);
                break;
                case "Firstname_desc":
               students = students.OrderByDescending(student => student.FirstMidName);
                    break;
                case "Date":
               students = students.OrderBy(student => student.EnrollmentDate);
                    break;
                case "date_desc":
               students = students.OrderByDescending(student => student.EnrollmentDate);
                    break;
                default:
                    students = students.OrderBy(student => student.LastName);
                    break;

            }

            int pageSize = 3;
            return View(await _context.Students.ToListAsync()); 
            
        } */
        //Create get, haarab vaatest andmed, mida create meetod vajab.
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Create meetod, sisestab andmebaasi uue õpilase. Insert new studnet into database

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstMidName,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
        // λ Mute crowbar wielding scientist λ

        // Strange intergalactic business man saying "Its time to choose"
    }
}
