﻿using Controllviewuniversity.Data;
using Controllviewuniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controllviewuniversity.Controllers
{
    public class StudentsController : Controller
    {
        
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context)
        {
            _context = context;
        }
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
    }
} 
