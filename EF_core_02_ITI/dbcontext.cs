using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EF_core_02_ITI
{
    internal class dbcontext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=.;Database=new_ITI_01;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<InstructorCourse> InstructorCourses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Student - Department (Many-to-One)
            modelBuilder.Entity<Student>()
            .HasOne(s => s.Department)
            .WithMany(d => d.Students)
            .HasForeignKey(s => s.DeptId)
            .IsRequired();


            // Instructor - Department (Many-to-One)
            modelBuilder.Entity<Instructor>()
            .HasOne(i => i.Department)
            .WithMany(d => d.Instructors)
            .HasForeignKey(i => i.DeptId)
            .IsRequired();


            // Department - Manager (One-to-One)
            modelBuilder.Entity<Department>()
            .HasOne(d => d.Manager)
            .WithOne(i => i.ManagedDepartment)
            .HasForeignKey<Department>(d => d.ManagerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);


            
            // StudentCourse (Many-to-Many with Grade)
            
            // StudentCourse (Composite Key)
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId)
                .OnDelete(DeleteBehavior.Cascade);


            
            // InstructorCourse (Many-to-Many with Evaluation)
            
            
            // InstructorCourse (Composite Key)
            modelBuilder.Entity<InstructorCourse>()
                .HasKey(ic => new { ic.InstructorId, ic.CourseId });

            modelBuilder.Entity<InstructorCourse>()
                .HasOne(ic => ic.Instructor)
                .WithMany(i => i.InstructorCourses)
                .HasForeignKey(ic => ic.InstructorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<InstructorCourse>()
                .HasOne(ic => ic.Course)
                .WithMany(c => c.InstructorCourses)
                .HasForeignKey(ic => ic.CourseId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Course>()
             .HasOne(c => c.Topic)
             .WithMany(t => t.Courses)
             .HasForeignKey(c => c.TopicId)
             .IsRequired();




        }





    }
}
