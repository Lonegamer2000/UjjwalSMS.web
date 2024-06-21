using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UjjwalSMS.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UjjwalSMS.Infrastructure.Entity_Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.FullName)
                .HasMaxLength(100)
                .IsRequired();

           

            builder.Property(p => p.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.PhoneNumber)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Class)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Section)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.studenturl)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(p => p.CreatedDate)
               .IsRequired()
               .HasDefaultValueSql("GETDATE()")
               .HasColumnType("DATETIME");

            builder.Property(p => p.ModifiedDate)
               .IsRequired()
               .HasDefaultValueSql("GETDATE()")
               .HasColumnType("DATETIME");

            //builder.HasMany(e => e.Courses)
            //    .WithMany(e => e.Students)
            //    .UsingEntity<StudentCourse>(
            //     l => l.HasOne(e => e.Course).WithMany(e => e.StudentCourses).HasForeignKey(e=>e.CourseId).OnDelete(DeleteBehavior.Restrict),
            //    r => r.HasOne(e => e.Student).WithMany(e => e.StudentCourses).HasForeignKey(e => e.StudentId).OnDelete(DeleteBehavior.Restrict));


        }
    }
    
}
