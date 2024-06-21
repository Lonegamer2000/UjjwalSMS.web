using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UjjwalSMS.Models.Entity
{
    public  class StudentCourse :BaseEntity
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
       
        public virtual Student student { get; set; }
        public virtual Course course { get; set; }


    }
}
