using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT.MVC.DATA/*.MetaData*/
{
        #region Cours
        public class CoursMetadata
        {
            //public int CourseId { get; set; }
            [Required(ErrorMessage = "* Course Name is Required *")]
            [Display(Name = "Course Name")]
            [StringLength(50, ErrorMessage = "* Course Name must be 50 characters or less *")]
            public string CourseName { get; set; }

            [Required(ErrorMessage = "* Course Description is Required *")]
            [Display(Name = "Description")]
            public string CourseDescription { get; set; }

            [Required(ErrorMessage = "* Credit Hours is Required *")]
            [Display(Name = "Credit Hours")]
            [Range(0, byte.MaxValue, ErrorMessage = "* Credit Hours must be between 0 and 8 *")]
            public byte CreditHours { get; set; }

            [StringLength(250, ErrorMessage = "* Curriculum must be 250 characters or less *")]
            [DisplayFormat(NullDisplayText = "[N/A]")]
            public string Curriculum { get; set; }

            [StringLength(500, ErrorMessage = "* Notes must be 500 characters or less *")]
            [DisplayFormat(NullDisplayText = "[N/A]")]
            public string Notes { get; set; }

            //[Required(ErrorMessage = "* Active is Required *")]
            [Display(Name = "Active")]
            public bool IsActive { get; set; }
        }
        [MetadataType(typeof(CoursMetadata))]
        public partial class Cours { }
        #endregion

        #region Enrollment
        public class EnrollmentMetadata
        {
            //public int EnrollmentId { get; set; }
            [Required(ErrorMessage = "* Student ID is Required *")]
            [Display(Name = "Student ID")]
            public int StudentId { get; set; }

            [Required(ErrorMessage = "* Scheduled Class ID is Required *")]
            [Display(Name = "Scheduled Class ID")]
            public int ScheduledClassId { get; set; }

            [Required(ErrorMessage = "* Enrollment Date is Required *")]
            [Display(Name = "Enrollment Date")]
            public System.DateTime EnrollmentDate { get; set; }
        }
        [MetadataType(typeof(EnrollmentMetadata))]
        public partial class Enrollment { }
        #endregion

        #region ScheduledClass
        public class ScheduledClassMetadata
        {
            //public int ScheduledClassId { get; set; }
            [Required(ErrorMessage = "* Course ID is Required *")]
            [Display(Name = "Course ID")]
            public int CourseId { get; set; }

            [Required(ErrorMessage = "* Start Date is Required *")]
            [Display(Name = "Start Date")]
            public System.DateTime StartDate { get; set; }

            [Required(ErrorMessage = "* End Date is Required *")]
            [Display(Name = "End Date")]
            public System.DateTime EndDate { get; set; }

            [Required(ErrorMessage = "* Instructor Name is Required *")]
            [Display(Name = "Instuctor")]
            [StringLength(40, ErrorMessage = "* Instructor Name must be 40 characters or less *")]
            public string InstructorName { get; set; }

            [Required(ErrorMessage = "* Location is Required *")]
            [Display(Name = "Location")]
            public string Location { get; set; }

            [Required(ErrorMessage = "* Class Status is Required *")]
            [Display(Name = "Class Status")]
            public int SCSID { get; set; }
        }
        [MetadataType(typeof(ScheduledClassMetadata))]
        public partial class ScheduledClass { }

        #endregion

        #region ScheduledClassStatus
        public class ScheduledClassStatusMetadata
        {
            //public int SCSID { get; set; }
            [Required(ErrorMessage = "* Class Status Name is Required *")]
            [StringLength(50, ErrorMessage = "* Class Status Name must be 50  characters or less *")]
            public string SCSName { get; set; }
        }
        [MetadataType(typeof(ScheduledClassStatusMetadata))]
        public partial class ScheduledClassStatus { }

        #endregion

        #region Student
        public class StudentMetadata
        {
            //public int StudentId { get; set; }
            [Required(ErrorMessage = "* First Name is Required *")]
            [StringLength(20, ErrorMessage = "* First Name must be 20 characters or less*")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "* Last Name is Required *")]
            [StringLength(20, ErrorMessage = " Last Name must be 20 characters or less*")]
            public string LastName { get; set; }

            [StringLength(25, ErrorMessage = "* Major must be 25 characters or less*")]
            [DisplayFormat(NullDisplayText = "[N/A]")]
            public string Major { get; set; }

            [DisplayFormat(NullDisplayText = "[N/A]")]
            [StringLength(50, ErrorMessage = "* Address must be 50 characters or less*")]
            public string Address { get; set; }

            [DisplayFormat(NullDisplayText = "[N/A]")]
            [StringLength(25, ErrorMessage = "* City must be 25 characters or less*")]
            public string City { get; set; }

            [DisplayFormat(NullDisplayText = "[N/A]")]
            [StringLength(2, ErrorMessage = "* State must be 2 characters or less*")]
            public string State { get; set; }

            [DisplayFormat(NullDisplayText = "[N/A]")]
            [StringLength(10, ErrorMessage = "* Zip  Code must be 10 characters or less*")]
            public string ZipCode { get; set; }

            [DisplayFormat(NullDisplayText = "[N/A]")]
            [StringLength(13, ErrorMessage = "* Phone must be 13 characters or less*")]
            [Display(Name = "Phone Number")]
            public string Phone { get; set; }

            [Required(ErrorMessage = "* Email is Required *")]
            [StringLength(60, ErrorMessage = "* Email must be 60 characters or less*")]
            public string Email { get; set; }

            [StringLength(100, ErrorMessage = "*Photo Url must be 100 characters or less*")]
            [DisplayFormat(NullDisplayText = "[N/A]")]
            public string PhotoUrl { get; set; }

            [Required(ErrorMessage = "* Student Status is Required *")]
            [Display(Name = "Student Status")]
            public int SSID { get; set; }
        }
        [MetadataType(typeof(StudentMetadata))]
        public partial class Student { }

        #endregion

        #region StudentStatus
        public class StudentStatusMetadata
        {
            //public int SSID { get; set; }
            [Required(ErrorMessage = "* Student Status Name is Required *")]
            [Display(Name = "Status Name")]
            [StringLength(30, ErrorMessage = "* Status Name must be 30 characters or less *")]
            public string SSName { get; set; }

            [Display(Name = "* Status Description *")]
            [StringLength(250, ErrorMessage = "* Status Description must be 250 characters or less *")]
            [DisplayFormat(NullDisplayText = "[N/A]")]
            public string SSDescription { get; set; }
        }
        [MetadataType(typeof(StudentStatusMetadata))]
        public partial class StudentStatus { }

        #endregion        
}
