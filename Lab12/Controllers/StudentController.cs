using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using Service;
using Lab12.Models;

namespace Lab12.Controllers
{
    public class StudentController : Controller
    {
        private StudentService service = new StudentService();

        public ActionResult IndexRazor()
        {
            var model = (from c in service.Get()
                         select new StudentModel
                         {
                             ID = c.studentID,
                             Code = c.studentCode,
                             Address = c.studentAddress,
                             Name = c.studentName,
                             LastName = c.studentLastName,
                         }).ToList();

            return View(model);
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getStudent(string id)
        {
            return Json(service.Get(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult createStudent(Student std)
        {
            service.Insert(std);
            string message = "SUCCESS";

            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

    }
}