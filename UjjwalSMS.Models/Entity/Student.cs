using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UjjwalSMS.Models.Entity
{
    public  class Student:BaseEntity
    {
        public string FullName { get; set; }
       
        public string Gender { get; set; }  
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Class {  get; set; }
        public string Section { get; set; }

        public string? studenturl { get; set; }

        [NotMapped]
        public IFormFile studentPhoto { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public virtual IEnumerable<Course> Courses { get; set; }
        public virtual IEnumerable<StudentCourse> StudentCourses { get; set; }



    }
}
