using DiPatternDemo.Models;
using DiPatternDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiPatternDemo.Controllers
{
   
    public class StudentController : Controller
    {
        private readonly IStudentService service;

        public StudentController(IStudentService service)
        {
            this.service = service;
        }
            // GET: StudentController
            public ActionResult Index()
        {
            var list = service.GetStudents();
            return View(list);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var student = service.GetStudentById(id);
            return View(student);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                int response = service.AddStudent(student);
                if(response >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMessage = "Something went wrong";
                    return View();
                }
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var res = service.GetStudentById(id);
            return View(res);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                int response = service.UpdateStudent(student);
                if (response >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMessage = "Something went wrong";
                    return View();
                }

            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var res = service.GetStudentById(id);
            return View(res);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int response = service.DeleteStudent(id);
                if (response >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMessage = "Something went wrong";
                    return View();
                }
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
    }
}
