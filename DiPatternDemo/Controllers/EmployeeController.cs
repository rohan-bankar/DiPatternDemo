using DiPatternDemo.Models;
using DiPatternDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiPatternDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService service;

        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }


        // GET: EmployeeController
        public ActionResult Index()
        {
            var model = service.GetEmployee();
            return View(model);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var employee = service.GetEmployeeById(id);
            return View(employee);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                int create = service.AddEmployee(employee);
                if(create != null)
                {
                    return RedirectToAction(nameof(Index));
                }
               else
                {
                    ViewBag.Errormessage = "something went wrong";
                    return View();
                }
            }
            catch(Exception ex)
            {
                ViewBag.Errormessage = ex.Message;
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var res = service.GetEmployeeById(id);
            return View(res);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                int update = service.UpdateEmployee(employee);
                if(update != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Errormessage = "something went wrong";
                    return View();
                }
            }
            catch(Exception ex)
            {
                ViewBag.Errormessage = ex.Message;
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var res = service.DeleteEmployee(id);
            return View(res);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int delete = service.DeleteEmployee(id);
                if (delete > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Errormessage = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Errormessage = ex.Message;
                return View();
            }
        }
    }
}
