﻿using System;
using Common;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Models.Response.ScholarRequest;
using Models.Models.Response.ScholarResponse;

namespace BACKEND_ZEAL_EDUCATION.Controllers.Scholar_Client
{
	public class ScholarDetailController : BaseController<ScholarDetailController>
    {
        public ScholarDetailController(ProjectSem3Context dbContext,
            ILogger<ScholarDetailController> logger,
            IConfiguration config)
            : base(dbContext, logger, config)
        {
        }

        [HttpGet]
        public IActionResult GetDeailScholarLogin()
        {
            var username = getCurrentUsernameLogin();
            var scholarAccount = _dbContext.Accounts.FirstOrDefault(m => m.Username== username);
            if (scholarAccount == null) return NotFound(Message.NOT_FOUND_SCHOLAR);
            var scholar = _dbContext.Scholars.FirstOrDefault(m => m.AccountId == scholarAccount.Id);
            if (scholar == null) return NotFound(Message.NOT_FOUND_SCHOLAR);
            var scholarCourses = from sc in _dbContext.ScholarCourses
                                 join cs in _dbContext.Courses on sc.CourseId equals cs.Id
                                 where sc.ScholarId == scholar.Id
                                 select new ScholarCourseViewable
                                 {
                                     Id = cs.Id,
                                     Name = cs.Name,
                                     CourseCode = cs.CourseCode,
                                     CourseType = cs.CourseType,
                                     Descreption = cs.Descreption,
                                     Purchased = sc.TuitionFees,
                                     AssignmetPoint = sc.AssignmetPoint,
                                     Image = cs.Image,
                                     Status = sc.Status,
                                     TestPoint = sc.TestPoint,
                                 };
            var scholarExam = from se in _dbContext.ScholarExams
                              join ex in _dbContext.Exams on se.ExamId equals ex.Id
                              where se.ScholarId == scholar.Id
                              select new ScholarExamViewable
                              {
                                  Id = ex.Id,
                                  Status = se.Status,
                                  StartDate = ex.StartDate,
                                  EndDate = ex.EndDate,
                                  Point = se.Point,
                                  ExamCode = ex.ExamCode,
                                  Descreption = ex.Descreption,
                              };

            var scholarViewable = new ScholarDetalViewable
            {
                Id = scholar.Id,
                Status = scholarAccount.Status,
                Name = scholarAccount.Name,
                Age = scholarAccount.Age,
                Address = scholarAccount.Address,
                Gender = scholarAccount.Gender,
                Descreption = scholarAccount.Descreption,
                DateOfbirth = scholarAccount.DateOfbirth,
                Batch = scholar.Batch,
                Faculty = scholar.Faculty,
                CourseList = scholarCourses.ToList(),
                Exams = scholarExam.ToList(),
            };
            return Ok(scholarViewable);
        }
    }
}

