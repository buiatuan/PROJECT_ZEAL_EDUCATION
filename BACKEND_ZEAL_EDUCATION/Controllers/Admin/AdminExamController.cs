using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Models.Request.ExamRequest;
using Models.Models.Response.ExamResponse;

namespace BACKEND_ZEAL_EDUCATION.Controllers.Admin
{
    public class AdminExamController : BaseController<AdminExamController>
    {
        public AdminExamController(ProjectSem3Context dbContext,
            ILogger<AdminExamController> logger,
            IConfiguration config)
            : base(dbContext, logger, config)
        {
        }

        // GET: AdminExam
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = _dbContext.Exams.Select(m =>
                new ExamBaseViewable
                {
                    Id = m.Id,
                    ExamCode = m.ExamCode,
                    StartDate = m.StartDate,
                    EndDate = m.EndDate,
                    CourseId = m.CourseId,
                    Descreption = m.Descreption,
                    UpdatedDate = m.UpdatedDate,
                    UpdatedBy = m.UpdatedBy,
                });
            return Ok(await result.ToListAsync());
        }

        // GET: AdminExam/Details/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _dbContext.Exams == null)
            {
                return NotFound();
            }

            var exam = await _dbContext.Exams
                .Select(m =>
                new ExamDetailViewable
                {
                    Id = m.Id,
                    ExamCode = m.ExamCode,
                    StartDate = m.StartDate,
                    EndDate = m.EndDate,
                    CourseId = m.CourseId,
                    Descreption = m.Descreption,
                    UpdatedDate = m.UpdatedDate,
                    UpdatedBy = m.UpdatedBy,
                    Course = m.Course
                }).FirstOrDefaultAsync(m => m.Id == id);
            if (exam == null)
            {
                return NotFound();
            }

            return Ok(exam);
        }

        // GET: AdminExam/Create
        [HttpPost]
        public IActionResult Create([FromBody] ExamCreateModel model)
        {
            var data = new Exam
            {
                ExamCode = model.ExamCode,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                CourseId = model.CourseId,
                Descreption = model.Descreption,
                CreatedDate = DateTime.Now,
                CreatedBy = "Admin"
            };
            _dbContext.Exams.Add(data);
            var eff = _dbContext.SaveChanges();
            return eff > 0 ? Ok("Success") : BadRequest("Failed");
        }

        // GET: AdminExam/Edit/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] ExamBaseModel exam_model)
        {
            if (id == null || _dbContext.Exams == null)
            {
                return NotFound();
            }

            var exam = await _dbContext.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            exam.ExamCode = exam_model.ExamCode;
            exam.StartDate = exam_model.StartDate;
            exam.EndDate = exam_model.EndDate;
            exam.CourseId = exam_model.CourseId;
            exam.Descreption = exam_model.Descreption;
            exam.UpdatedDate = DateTime.Now;
            exam.UpdatedBy = "Admin";

            _dbContext.Exams.Update(exam);
            var eff = _dbContext.SaveChanges();
            return eff > 0 ? Ok(Message.SUCCESS) : BadRequest(Message.FAILED);
        }

        // GET: AdminExam/Delete/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            if (id == null || _dbContext.Exams == null)
            {
                return NotFound();
            }

            var exam = await _dbContext.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            return Ok(Message.SUCCESS);
        }

        private bool ExamExists(int id)
        {
          return (_dbContext.Exams?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
