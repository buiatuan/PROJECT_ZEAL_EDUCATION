using System;
namespace Models.Models.Request
{
	public class CourseRegisterModel
	{
        //scholar
        public int? AccountId { get; set; }

        public int? FacultyId { get; set; }

        public int? BatchId { get; set; }

        public string? ScholarCode { get; set; }

        //course
        public string? CourseCode { get; set; }

        public string? Name { get; set; }
    }
}

