using System;
namespace Models.Models.Response.CourseRegisterResponse
{
	public class ConfirmedRegisterCourse
	{
        public decimal? Purchased { get; set; }

        public decimal? TuitionFees { get; set; }

        public int? ScholarId { get; set; }

        public int? CourseId { get; set; }
    }
}

