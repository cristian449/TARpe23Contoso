using Controllviewuniversity.Models;

namespace Controllviewuniversity.Data
{
    public class DbInitializer
    {
        public static void initialize(SchoolContext context) 
        { 
        context.Database.EnsureCreated();

        if context.Students Any()) 
            {


                return;
            }

            var students = new Student[]
            {
                new.Student(FirstMidName="Arjom")

            }
                    
            
        }
    }
}
