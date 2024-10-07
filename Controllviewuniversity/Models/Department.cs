using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]

        public decimal Budget { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StarDate { get; set; }

        /*
         *  Kaks omapärast andmetüüpi
         */
        [Display(Name = "The Person who will annihilate us all")]
        public string? DarkLord { get; set; }
        
        public int? Cigarettes { get; set; }

        public int? InstructorID { get; set; }
        [Timestamp]
        public byte? RowVersion { get; set; }

        public Instructor? Administrator { get; set; }

        public ICollection<Course>? Courses { get;}

        
    }
}
