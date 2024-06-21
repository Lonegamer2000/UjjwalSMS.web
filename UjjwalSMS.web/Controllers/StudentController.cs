using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UjjwalSMS.Infrastructure.IRepository;
using UjjwalSMS.Models.Entity;
using UjjwalSMS.web.Data;
using UjjwalSMS.web.Models;

namespace UjjwalSMS.web.Controllers
{
    public class StudentController : Controller
    {
        private readonly ICrudService<Student> _student;
        private readonly ICrudService<Course> _course;
        private readonly ICrudService<StudentCourse> _studentCourse;
        private readonly UserManager<ApplicationUser> _user;

        public StudentController(ICrudService<Student> student, ICrudService<Course> course, ICrudService<StudentCourse> studentCourse, 
            UserManager<ApplicationUser> user)
        {
            _student = student;
            _course = course;
            _studentCourse = studentCourse;
            _user = user;
        }

        public async Task<IActionResult> Index()
        {

            var student = await _student.GetAllAsync();
            return View(student);
        }
       // [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> AddEdit(int id)
        {
            Student student = new Student();
            if (id != 0)
            {
                student = await _student.GetAsync(id);
            }
            return View(student);

        }
        [HttpPost]
        public async Task<IActionResult> AddEdit(Student student)
        {
            var UserId = _user.GetUserId(HttpContext.User);
            if (student.Id == 0)
            {
                student.CreatedBy = UserId;
                student.CreatedDate = DateTime.Now;
                await _student.InsertAsync(student);
            }
            else if (student.Id != 0)
            {
                Student studentInfo = await _student.GetAsync(student.Id);
                studentInfo.FullName = student.FullName;
                studentInfo.Gender = student.Gender;
                studentInfo.Email = student.Email;
                studentInfo.Address = student.Address;
                studentInfo.PhoneNumber = student.PhoneNumber;
                studentInfo.Section = student.Section;
                studentInfo.ModifiedDate = DateTime.Now;
                studentInfo.ModifiedBy = UserId;
                await _student.UpdateAsync(studentInfo);
            }

            return RedirectToAction(nameof(Index));

        }
    }
}
