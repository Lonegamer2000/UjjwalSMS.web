using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UjjwalSMS.Infrastructure.IRepository;
using UjjwalSMS.Models.Entity;
using UjjwalSMS.web.Models;

namespace UjjwalSMS.web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICrudService<Student> _student;
        private readonly ICrudService<Course> _course;
        private readonly ICrudService<StudentCourse> _studentCourse;
        private readonly UserManager<ApplicationUser> _user;

        public CourseController(ICrudService<Student> student, ICrudService<Course> course, 
            ICrudService<StudentCourse> studentCourse, UserManager<ApplicationUser> user)
        {
            _student = student;
            _course = course;
            _studentCourse = studentCourse;
            _user = user;
        }

        public async Task<IActionResult> Index()
        {
            var course = await _course.GetAllAsync();
            return View(course);
        }
     //  [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> AddEdit(int id)
        {
            Course course = new Course();
            if (id != 0)
            {
                course = await _course.GetAsync(id);
            }
            return View(course);

        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(Course course)
        {
            if (ModelState.IsValid)
            {
                var UserId = _user.GetUserId(HttpContext.User);
                if (course.Id == 0)
                {
                    course.CreatedBy = UserId;
                    course.CreatedDate = DateTime.Now;
                    await _course.InsertAsync(course);
                }
                else if (course.Id != 0)
                {
                    Course updated_course = await _course.GetAsync(course.Id);
                    updated_course.IsActive = course.IsActive;
                    updated_course.CourseName = course.CourseName;
                    updated_course.CourseDescription = course.CourseDescription;
                    updated_course.ModifiedDate = DateTime.Now;
                    updated_course.ModifiedBy = UserId;
                    await _course.UpdateAsync(updated_course);
                }
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(AddEdit));

        }
        public async Task<IActionResult> Enroll(int Id, int StuId)
        {
            var studentCourse = new StudentCourse();
            studentCourse.StudentId = StuId;
            studentCourse.CourseId = Id;
            await _studentCourse.InsertAsync(studentCourse);
            return RedirectToAction(nameof(Index));
        }


    }
}
