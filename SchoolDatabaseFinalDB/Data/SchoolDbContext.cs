using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SchoolDatabaseFinalDB.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SchoolDatabaseFinalDB.Data
{
    public partial class SchoolDbContext : DbContext
    {
        public SchoolDbContext()
        {
        }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=MARTIN; Initial Catalog=SchoolDatabaseFinal; Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseName).HasMaxLength(50);

                entity.Property(e => e.FkEmployeeId).HasColumnName("FK_EmployeeId");

                entity.Property(e => e.FkStudentId).HasColumnName("FK_StudentId");

                entity.HasOne(d => d.FkEmployee)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.FkEmployeeId)
                    .HasConstraintName("FK_Course_Employee");

                entity.HasOne(d => d.FkStudent)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.FkStudentId)
                    .HasConstraintName("FK_Course_Student");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.DateOfEmp).HasColumnType("date");

                entity.Property(e => e.EmployeeRole).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.Property(e => e.SchoolName).HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.GradeDate).HasColumnType("date");

                entity.Property(e => e.StudentGrade).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
