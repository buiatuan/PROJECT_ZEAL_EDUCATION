using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Models.Entites;

public partial class ProjectSem3Context : DbContext
{
    public ProjectSem3Context()
    {
    }

    public ProjectSem3Context(DbContextOptions<ProjectSem3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Batch> Batches { get; set; }

    public virtual DbSet<BatchCourse> BatchCourses { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<ReportScholar> ReportScholars { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Scholar> Scholars { get; set; }

    public virtual DbSet<ScholarCourse> ScholarCourses { get; set; }

    public virtual DbSet<ScholarExam> ScholarExams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-86M55DA\\SQLEXPRESS;Initial Catalog=PROJECT_SEM_3;Integrated Security=True;TrustServerCertificate=Yes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__account__3213E83FB75F595C");

            entity.ToTable("account");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(300)
                .HasColumnName("address");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("createdBy");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.DateOfbirth)
                .HasColumnType("datetime")
                .HasColumnName("dateOfbirth");
            entity.Property(e => e.Descreption)
                .HasMaxLength(300)
                .HasColumnName("descreption");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.Salt)
                .HasMaxLength(62)
                .IsUnicode(false)
                .HasColumnName("salt");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updatedBy");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updatedDate");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__account__roleId__4AB81AF0");
        });

        modelBuilder.Entity<Batch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__batch__3213E83F73C2FA0B");

            entity.ToTable("batch");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BatchCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("batchCode");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("createdBy");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.FacultyId).HasColumnName("facultyId");
            entity.Property(e => e.FromDate)
                .HasColumnType("datetime")
                .HasColumnName("fromDate");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.ToDate)
                .HasColumnType("datetime")
                .HasColumnName("toDate");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updatedBy");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updatedDate");
        });

        modelBuilder.Entity<BatchCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__batchCou__3213E83F31DD89D2");

            entity.ToTable("batchCourse");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BatchId).HasColumnName("batchId");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.Point).HasColumnName("point");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Batch).WithMany(p => p.BatchCourses)
                .HasForeignKey(d => d.BatchId)
                .HasConstraintName("FK__batchCour__batch__5441852A");

            entity.HasOne(d => d.Course).WithMany(p => p.BatchCourses)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__batchCour__cours__5535A963");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__course__3213E83FCD280F61");

            entity.ToTable("course");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseCode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("courseCode");
            entity.Property(e => e.CourseType)
                .HasMaxLength(255)
                .HasColumnName("courseType");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("createdBy");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.Descreption)
                .HasColumnType("text")
                .HasColumnName("descreption");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.TuitionFees)
                .HasColumnType("decimal(15, 8)")
                .HasColumnName("tuitionFees");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updatedBy");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updatedDate");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__exam__3213E83F99DC134E");

            entity.ToTable("exam");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("createdBy");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.Descreption)
                .HasColumnType("text")
                .HasColumnName("descreption");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("endDate");
            entity.Property(e => e.ExamCode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("examCode");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updatedBy");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updatedDate");

            entity.HasOne(d => d.Course).WithMany(p => p.Exams)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__exam__courseId__52593CB8");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__faculty__3213E83F6C26873D");

            entity.ToTable("faculty");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("createdBy");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.Descreption)
                .HasMaxLength(200)
                .HasColumnName("descreption");
            entity.Property(e => e.FacultyCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("facultyCode");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updatedBy");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updatedDate");
        });

        modelBuilder.Entity<ReportScholar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reportSc__3213E83F1C7CAF85");

            entity.ToTable("reportScholar");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("createdBy");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Path)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("path");
            entity.Property(e => e.ScholarId).HasColumnName("scholarId");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("updatedBy");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updatedDate");

            entity.HasOne(d => d.Scholar).WithMany(p => p.ReportScholars)
                .HasForeignKey(d => d.ScholarId)
                .HasConstraintName("FK__reportSch__schol__534D60F1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__role__3213E83F39E37F38");

            entity.ToTable("role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("createdBy");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.Descreption)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descreption");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Scholar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__scholar__3213E83F755DCD52");

            entity.ToTable("scholar");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("accountId");
            entity.Property(e => e.BatchId).HasColumnName("batchId");
            entity.Property(e => e.FacultyId).HasColumnName("facultyId");

            entity.HasOne(d => d.Account).WithMany(p => p.Scholars)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__scholar__account__628FA481");

            entity.HasOne(d => d.Batch).WithMany(p => p.Scholars)
                .HasForeignKey(d => d.BatchId)
                .HasConstraintName("FK__scholar__batchId__4D94879B");

            entity.HasOne(d => d.Faculty).WithMany(p => p.Scholars)
                .HasForeignKey(d => d.FacultyId)
                .HasConstraintName("FK__scholar__faculty__4CA06362");
        });

        modelBuilder.Entity<ScholarCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__scholarC__3213E83F3EE27AC4");

            entity.ToTable("scholarCourse");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssignmetPoint).HasColumnName("assignmetPoint");
            entity.Property(e => e.CourseId).HasColumnName("courseId");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.Purchased)
                .HasColumnType("decimal(15, 8)")
                .HasColumnName("purchased");
            entity.Property(e => e.ScholarId).HasColumnName("scholarId");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TestPoint).HasColumnName("testPoint");
            entity.Property(e => e.TuitionFees)
                .HasColumnType("decimal(15, 8)")
                .HasColumnName("tuitionFees");

            entity.HasOne(d => d.Course).WithMany(p => p.ScholarCourses)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__scholarCo__cours__4F7CD00D");

            entity.HasOne(d => d.Scholar).WithMany(p => p.ScholarCourses)
                .HasForeignKey(d => d.ScholarId)
                .HasConstraintName("FK__scholarCo__schol__4E88ABD4");
        });

        modelBuilder.Entity<ScholarExam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__scholarE__3213E83FAA9447E7");

            entity.ToTable("scholarExam");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.ExamId).HasColumnName("examId");
            entity.Property(e => e.Point).HasColumnName("point");
            entity.Property(e => e.ScholarId).HasColumnName("scholarId");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Exam).WithMany(p => p.ScholarExams)
                .HasForeignKey(d => d.ExamId)
                .HasConstraintName("FK__scholarEx__examI__5165187F");

            entity.HasOne(d => d.Scholar).WithMany(p => p.ScholarExams)
                .HasForeignKey(d => d.ScholarId)
                .HasConstraintName("FK__scholarEx__schol__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
