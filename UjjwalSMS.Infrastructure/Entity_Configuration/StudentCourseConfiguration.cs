using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UjjwalSMS.Models.Entity;

namespace UjjwalSMS.Infrastructure.Entity_Configuration
{
    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasAlternateKey(p => new { p.StudentId, p.CourseId });
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();
            //builder.HasOne(e=>e.Course)
            //    .WithMany(e=>e.StudentCourses)
            //    .HasForeignKey(e=>e.CourseId)
            //    .OnDelete(DeleteBehavior.Restrict);
            //builder.HasOne(e => e.Student)
            //    .WithMany(e => e.StudentCourses)
            //    .HasForeignKey(e => e.StudentId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
