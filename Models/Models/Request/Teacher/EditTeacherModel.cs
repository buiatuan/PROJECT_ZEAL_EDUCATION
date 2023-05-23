﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models.Request.Teacher
{
    public class EditTeacherModel
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? Descreption { get; set; }
        public string? Avatar { get; set; }
        public DateTime? DateOfbirth { get; set; }
    }
}
