using System;
using Models.Entities;

namespace Models.Models.Request.RegisterRequest
{
    public class ScholarRegisterModel
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Name { get; set; } = null!;

        public int? Age { get; set; }

        public string? Gender { get; set; }

        public string? Address { get; set; }

        public string? Descreption { get; set; }

        public int? RoleId { get; set; }

        public DateTime? DateOfbirth { get; set; }
    }
}