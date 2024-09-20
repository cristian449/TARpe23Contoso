using ContosoUniversity.Controllers;
using ContosoUniversity.Models;

namespace ContosoUniversity.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            ////Teeb, kindaaks, et andmebaas thakse, või oleks olemas
            //context.Database.EnsureCreated();

            ////Kui õpliaste tabelis juba on õpilasi, siis väljub funktsioon
            if (context.Students.Any())
            {
               return;
            }

            var students = new Student[] {

               new Student { FirstMidName = "Star", LastName = "Wars", EnrollmentDate = DateTime.Parse("2069-04-26") },
               new Student{FirstMidName="Independence",LastName="Day", EnrollmentDate=DateTime.Parse("2002-09-01") },
               new Student{FirstMidName="Atruro", LastName="Anand", EnrollmentDate=DateTime.Parse("2003-09-01") },
               new Student{FirstMidName="Gytis", LastName="Barzdukas", EnrollmentDate=DateTime.Parse("2002-09-01") },
               new Student{FirstMidName="Yan", LastName="Li", EnrollmentDate=DateTime.Parse("2002-09-01") },
               new Student{FirstMidName="Poggy", LastName="Justice", EnrollmentDate=DateTime.Parse("2002-09-01") },
               new Student{FirstMidName="Laura", LastName="Norman", EnrollmentDate=DateTime.Parse("2001-09-01") },
               new Student{FirstMidName="Nino", LastName="Olivetto", EnrollmentDate=DateTime.Parse("2003-09-01") },
               new Student{FirstMidName="Carson", LastName="Alexander", EnrollmentDate=DateTime.Parse("2005-09-01") },
               new Student{FirstMidName="Jüri", LastName="Vaitmaa", EnrollmentDate=DateTime.Parse("2005-09-01") },
              new Student{FirstMidName="Harrison", LastName="Ford", EnrollmentDate=DateTime.Parse("2023-08-26") }
                };
            context.Students.AddRange(students);
            context.SaveChanges();


            
            if (context.Courses.Any())
            {
                return;
            }

            var courses = new Course[]
            {
            new Course{CourseID=1050,Title="Chemisrty",Credits=3},
            new Course{CourseID=4822,Title="Mikroökonoomika",Credits=3 },
            new Course{CourseID=4821,Title="Mikroökonoomika",Credits=3 },
            new Course{CourseID=1045,Title="Calculus",Credits=4 },
            new Course{CourseID=3141,Title="Trigonomeetria",Credits=4 },
            new Course{CourseID=2021,Title="Kompositsioon",Credits=3 },
            new Course{CourseID=2842,Title="Kirjandus",Credits=4 },
            new Course{CourseID=9001,Title="Arvutimängue ajalugu",Credits=1 },
            new Course{CourseID=6666,Title="Dark magic",Credits=4 },
            };
            context.Courses.AddRange(courses);
            context.SaveChanges();

            if (context.Enrollments.Any()) { return; }

            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1, CourseID=1050, Grade=Grade.A },
                new Enrollment{StudentID=1, CourseID=4822, Grade=Grade.C },
                new Enrollment{StudentID=1, CourseID=4821, Grade=Grade.B },

                new Enrollment{StudentID=2, CourseID=1845, Grade=Grade.B },
                new Enrollment{StudentID=2, CourseID=3141, Grade=Grade.F },
                new Enrollment{StudentID=2, CourseID=2021, Grade=Grade.F },

                new Enrollment{StudentID=3, CourseID=1050},

                new Enrollment{StudentID=4, CourseID=1050},
                new Enrollment{StudentID=4, CourseID=4822, Grade=Grade.F },

                new Enrollment{StudentID=5, CourseID=4822, Grade=Grade.C },

                new Enrollment{StudentID=6, CourseID=1045},

                new Enrollment{StudentID=7, CourseID=3141, Grade=Grade.A },

                new Enrollment{StudentID=10, CourseID=6666, Grade=Grade.A },
            };
            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();


            if (context.Instructors.Any())
            {
                return;
            }

            var instructors = new Instructor[]
            {
                new Instructor {FirstMidName = "Ban", LastName = "ana", HireDate = DateTime.Parse("2042-04-19"), Mood = Mood.Darklord, VocationCredential = "Complicated", WorkYears = 42},
                new Instructor {FirstMidName = "Quantum", LastName = "Kiin", HireDate = DateTime.Parse("2012-04-19"), Mood = Mood.Darklord, VocationCredential = "Basement", WorkYears = 42},
                new Instructor {FirstMidName = "Owo", LastName = "UwU", HireDate = DateTime.Parse("2002-04-19"), Mood = Mood.Darklord, VocationCredential = "Professional Dissapointment", WorkYears = 24},
                new Instructor {FirstMidName = "Cursed", LastName = "Child", HireDate = DateTime.Parse("2013-04-19"), Mood = Mood.Darklord, VocationCredential = "Professional child", WorkYears = 42},
                new Instructor {FirstMidName = "Pain", LastName = "Misery", HireDate = DateTime.Parse("2016-04-19"), Mood = Mood.Darklord, VocationCredential = "Complicated", WorkYears = 42},
                new Instructor {FirstMidName = "Zomer", LastName = "Bimpson", HireDate = DateTime.Parse("2001-04-19"), Mood = Mood.Darklord, VocationCredential = "Complicated", WorkYears = 42},
                new Instructor {FirstMidName = "Donald J", LastName = "Trumo", HireDate = DateTime.Parse("1991-04-19"), Mood = Mood.Darklord, VocationCredential = "Complicated", WorkYears = 42},
                new Instructor {FirstMidName = "God", LastName = "Help us", HireDate = DateTime.Parse("1992-02-19"), Mood = Mood.Darklord, VocationCredential = "Complicated", WorkYears = 42},
                new Instructor {FirstMidName = "This is", LastName = "Cursed", HireDate = DateTime.Parse("1592-01-12"), Mood = Mood.Darklord, VocationCredential = "Complicated", WorkYears = 42},

            };




            ////objekyi õpilastega, mis lisatakse siis, kui õpilasi sisestatud ei ole
            //var students = new Student[]
            //{
            //    new Student{FirstMidName="Star",LastName="Wars", EnrollmentDate=DateTime.Parse("2069-04-26")},
            //    new Student{FirstMidName="Independence",LastName="Day", EnrollmentDate=DateTime.Parse("2002-09-01") },
            //    new Student{FirstMidName="Atruro", LastName="Anand", EnrollmentDate=DateTime.Parse("2003-09-01") },
            //    new Student{FirstMidName="Gytis", LastName="Barzdukas", EnrollmentDate=DateTime.Parse("2002-09-01") },
            //    new Student{FirstMidName="Yan", LastName="Li", EnrollmentDate=DateTime.Parse("2002-09-01") },
            //    new Student{FirstMidName="Poggy", LastName="Justice", EnrollmentDate=DateTime.Parse("2002-09-01") },
            //    new Student{FirstMidName="Laura", LastName="Norman", EnrollmentDate=DateTime.Parse("2001-09-01") },
            //    new Student{FirstMidName="Nino", LastName="Olivetto", EnrollmentDate=DateTime.Parse("2003-09-01") },
            //    new Student{FirstMidName="Carson", LastName="Alexander", EnrollmentDate=DateTime.Parse("2005-09-01") },
            //    new Student{FirstMidName="Jüri", LastName="Vaitmaa", EnrollmentDate=DateTime.Parse("2005-09-01") },
            //    new Student{FirstMidName="Harrison", LastName="Ford", EnrollmentDate=DateTime.Parse("2023-08-26") },
            //};

            //// Iga õpilane lisatakse ükssaaval läbi forreach tsükli
            //foreach (Student student in students) 
            //{
            //    context.Students.Add(student);
            //}
            ////Ja andmebaasi muudatused salvestatakse
            //context.SaveChanges();

            ////Eelnev struktuur, kuid kursustega: \/
            //var courses = new Course[]
            //{
            //new Course{CourseID=1050,Title="Chemisrty",Credits=3},
            //new Course{CourseID=4822,Title="Mikroökonoomika",Credits=3 },
            //new Course{CourseID=4821,Title="Mikroökonoomika",Credits=3 },
            //new Course{CourseID=1045,Title="Calculus",Credits=4 },
            //new Course{CourseID=3141,Title="Trigonomeetria",Credits=4 },
            //new Course{CourseID=2021,Title="Kompositsioon",Credits=3 },
            //new Course{CourseID=2842,Title="Kirjandus",Credits=4 },
            //new Course{CourseID=9001,Title="Arvutimängue ajalugu",Credits=1 },
            //new Course{CourseID=6666,Title="Dark magic",Credits=4 },
            //};

            //foreach (Course course in courses) 
            //{ 
            //    context.Courses.Add(course);
            //}
            //context.SaveChanges();

            //var enrollments = new Enrollment[]
            //{
            //    new Enrollment{StudentID=1, CourseID=1050, Grade=Grade.A },
            //    new Enrollment{StudentID=1, CourseID=4822, Grade=Grade.C },
            //    new Enrollment{StudentID=1, CourseID=4821, Grade=Grade.B },

            //    new Enrollment{StudentID=2, CourseID=1845, Grade=Grade.B },
            //    new Enrollment{StudentID=2, CourseID=3141, Grade=Grade.F },
            //    new Enrollment{StudentID=2, CourseID=2021, Grade=Grade.F },

            //    new Enrollment{StudentID=3, CourseID=1050},

            //    new Enrollment{StudentID=4, CourseID=1050},
            //    new Enrollment{StudentID=4, CourseID=4822, Grade=Grade.F },

            //    new Enrollment{StudentID=5, CourseID=4822, Grade=Grade.C },

            //    new Enrollment{StudentID=6, CourseID=1045},

            //    new Enrollment{StudentID=7, CourseID=3141, Grade=Grade.A },

            //    new Enrollment{StudentID=10, CourseID=6666, Grade=Grade.A },

            //};
            //foreach (Enrollment enrollment in enrollments)
            //{
            //    context.Enrollments.Add(enrollment);
            //}
            //context.SaveChanges();
        }
    }
}

