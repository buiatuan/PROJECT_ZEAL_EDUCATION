﻿using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing;
using Models.Entities;
using Scholar_model = Models.Entities.Scholar;
using Models.Models.Request.CourseRequest;
using Models.Models.Response.CourseResponse;
using static System.Net.Mime.MediaTypeNames;
using Models.Models.Response.CourseRegisterResponse;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Authorization;

namespace BACKEND_ZEAL_EDUCATION.Controllers.Admin
{
    [AllowAnonymous]
    public class AdminCourseController : BaseController<AdminCourseController>
    {
        public AdminCourseController(ProjectSem3Context dbContext,
            ILogger<AdminCourseController> logger,
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
                Id = id,
                Name = course.Name ?? null,
                CourseCode = course.CourseCode ?? null,
                TuitionFees = course.TuitionFees ?? null,
                CourseType = course.CourseType ?? null,
                Descreption = course.Descreption ?? "",
                CreatedDate = course.CreatedDate ?? null,
                UpdatedDate = course.UpdatedDate ?? null,
                Image = course.Image ?? "",
                Scholars = courseScholar.ToList() ?? new List<Scholar_model>(),
            };
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CourseCreateModel model)
        {
            var data = new Course
            {
                CourseCode = model.CourseCode,
                CourseType = model.CourseType,
                Descreption = model.Descreption,
                CreatedBy = "System",
                CreatedDate = DateTime.Now,
                TuitionFees = model.TuitionFees,
                Name = model.Name,
                Image = model.Image,
            };
            _dbContext.Courses.Add(data);
            var eff = _dbContext.SaveChanges();
            return eff > 0 ? Ok(Message.SUCCESS) : BadRequest(Message.FAILED);
        }

        [HttpPut("{id:int}")]
        public IActionResult Edit([FromRoute] int id, [FromBody] CourseCreateModel model)
        {
            var course = _dbContext.Courses.Find(id);
            if (course == null) return NotFound(Message.NOT_FOUND_COURSE);
            course.Name = model.Name;
            course.CourseCode = model.CourseCode;
            course.CourseType = model.CourseType;
            course.Descreption = model.Descreption;
            course.TuitionFees = model.TuitionFees;
            course.Image = model.Image;
            course.UpdatedBy = "System";
            course.UpdatedDate = DateTime.Now;
            _dbContext.Courses.Update(course);
            var eff = _dbContext.SaveChanges();
            return eff > 0 ? Ok(Message.SUCCESS) : BadRequest(Message.FAILED);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var course = _dbContext.Courses.Find(id);
            if (course == null) return NotFound(Message.NOT_FOUND_COURSE);
            course.Status = 0;
            _dbContext.Courses.Update(course);
            var eff = _dbContext.SaveChanges();
            return eff > 0 ?  Ok(Message.SUCCESS) : BadRequest(Message.FAILED);
        }


        //0 - refused
        //2 - pending
        //1 - accepted
        [HttpGet("Pending")]
        public IActionResult GetPending()
        {
            var pending_request = _dbContext.ScholarCourses.Where(m => m.Status == 2);
            if (pending_request == null)
            {
                return NotFound(Message.NOT_FOUND_DATA);
            }
            return Ok(pending_request);
        }

        [HttpGet("Accepted")]
        public IActionResult GetAccepted()
        {
            var completed_request = _dbContext.ScholarCourses.Where(m => m.Status == 1);
            if (completed_request == null)
            {
                return NotFound(Message.NOT_FOUND_DATA);
            }
            return Ok(completed_request);
        }

        [HttpGet("Refused")]
        public IActionResult GetRefused()
        {
            var refused_request = _dbContext.ScholarCourses.Where(m => m.Status == 0);
            if (refused_request == null)
            {
                return NotFound(Message.NOT_FOUND_DATA);
            }
            return Ok(refused_request);
        }

        [HttpPut("Confirmed")]
        public IActionResult ConfirmedCreate(ConfirmedRegisterCourse model)
        {
            var data = _dbContext.ScholarCourses.Where(m => m.Id == model.Id).First();
            if (data == null)
            {
                return NotFound(Message.NOT_FOUND_DATA);
            }
            data.Status = 1;
            _dbContext.ScholarCourses.Update(data);
            var eff = _dbContext.SaveChanges();
            return eff > 0 ? Ok(Message.SUCCESS) : BadRequest(Message.FAILED);
        }
    }
}
