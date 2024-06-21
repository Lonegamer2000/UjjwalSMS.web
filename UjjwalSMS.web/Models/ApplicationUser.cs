using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace UjjwalSMS.web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }  
        public string LastName { get; set; }
        public int StudentId { get; set; }
        public string Address { get; set; } 

        //public string? Phonenumber { get; set; }
        public string UserRoleId { get; set; }
        public bool IsActive { get; set; }
        public string? ProfileUrl { get; set; }
        [NotMapped]
        public IFormFile? ProfilePicture { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModidifiedDate { get; set; }
        public string? ModidiedBy { get; set ; }
    }
}
