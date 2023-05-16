using System;
namespace Models.Models.Request
{
	public class CourseRegisterModel
	{
        //account
        public string NameScholar { get; set; } = null!;

        public DateTime? DateOfbirth { get; set; }

        //scholar
        public string ScholarCode { get; set; }

        //batch
        public string? BatchName { get; set; }

        //faculty
        public string? FacultyName { get; set; }

        //course
        public string CourseCode { get; set; }

        public string NameCourse { get; set; }

        public string? ReceiptImage { get; set; }
    }
}

