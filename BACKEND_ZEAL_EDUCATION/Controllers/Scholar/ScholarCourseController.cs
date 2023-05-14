using System;
using BACKEND_ZEAL_EDUCATION.Controllers.Admin;
using Common;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Models.Response.CourseResponse;

namespace BACKEND_ZEAL_EDUCATION.Controllers.Scholar
{
	public class ScholarCourseController : BaseController<ScholarCourseController>
    {
        public ScholarCourseController(ProjectSem3Context dbContext,
            ILogger<ScholarCourseController> logger,
            IConfiguration config)
            : base(dbContext, logger, config)
        {
        }

        [HttpGet]
        public IActionResult GetListCourse()
        {
            var courseList = _dbContext.Courses;
            return Ok(courseList);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDetail(int id)
        {
            var course = _dbContext.Courses.Find(id);
            if (course == null) return NotFound(Message.NOT_FOUND_COURSE);
            var courseScholar = from sc in _dbContext.ScholarCourses
                                join scholar in _dbContext.Scholars on sc.ScholarId equals scholar.Id
                                where sc.CourseId == id
                                select scholar;
            var result = new CourseDetailViewModel
            {
                Name = course.Name ?? null,
                CourseCode = course.CourseCode ?? null,
                TuitionFees = course.TuitionFees ?? null,
                CourseType = course.CourseType ?? null,
                Descreption = course.Descreption ?? "",
                Image = course.Image ?? "",
            };
            return Ok(result);
        }
    }
}

