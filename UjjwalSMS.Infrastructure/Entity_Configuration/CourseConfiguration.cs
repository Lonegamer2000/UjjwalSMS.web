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
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(p => p.Id)
      .ValueGeneratedOnAdd();

            builder.Property(p => p.CourseName)
                .HasMaxLength(100)
                .IsRequired();


            builder.HasMany(e => e.Students)
                .WithMany(e => e.Courses)
                .UsingEntity<StudentCourse>(
                l => l.HasOne(e => e.student).WithMany(e => e.StudentCourses).HasForeignKey(e => e.StudentId).OnDelete(DeleteBehavior.Cascade),
                r => r.HasOne(e => e.course).WithMany(e => e.StudentCourses).HasForeignKey(e => e.CourseId).OnDelete(DeleteBehavior.Cascade)
                );

        }
    }
}
