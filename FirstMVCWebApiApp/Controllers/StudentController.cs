using FirstMVCWebApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVCWebApiApp.Controllers
{
    
    //[RoutePrefix("student")]
    //[Route("{action=index}")]
    public class StudentController : Controller
    {

        private static List<Student> studentList;
        static StudentController()
        {
            studentList = new List<Student>{
                            new Student() { StudentId = 1, StudentName = "John", Age = 18 } ,
                            new Student() { StudentId = 2, StudentName = "Steve",  Age = 21 } ,
                            new Student() { StudentId = 3, StudentName = "Bill",  Age = 25 } ,
                            new Student() { StudentId = 4, StudentName = "Ram" , Age = 20 } ,
                            new Student() { StudentId = 5, StudentName = "Ron" , Age = 31 } ,
                            new Student() { StudentId = 4, StudentName = "Chris" , Age = 17 } ,
                            new Student() { StudentId = 4, StudentName = "Rob" , Age = 19 }
                        };
        }

        [Route]
        public ActionResult Index()
        {            
            return View(studentList);
        }


        //[Route("Student/Get")]
        public ActionResult GetAll()
        {
            return View(studentList);
        }

        //[Route("find/{id:int}")]
        public ActionResult GetById(int id)
            => id == 0 ? null : View(studentList.FirstOrDefault(x => x.StudentId == id));


        //[Route("AddNew")]   
        public ActionResult AddNew(Student student)
        {
           
            student.StudentId = studentList.Max(x => x.StudentId) + 1;
            studentList.Add(student);
            
           return RedirectToAction("index");
        }

        //[HandleError]
        [HttpGet]
        [Route("current/{id:int?}")]
        public ActionResult CurrentStudent(int? id)
        {
            var current = (id == null)? null :studentList.Where(x => x.StudentId == id).FirstOrDefault();

            //throw new Exception("we are testing life..");
            return View(current);
        }

        
        [HttpPost]
        public ActionResult UpdateOrCreate(Student std, string submit)
        {

            if (string.Compare(submit, "cancel",
                StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return RedirectToAction("index");
            }

            if (!ModelState.IsValid)
            {
                return View("CurrentStudent", std);
            }
            else
            {
                bool isExist = studentList.Any(
                    x=> x.Age == std.Age &&
                    x.StudentName == std.StudentName);

                if (isExist)
                {
                    ModelState.AddModelError(string.Empty, "cet element existe déjà");
                    return View("CurrentStudent", std);
                } 

                return RedirectToAction("AddNew", std);
            }
            
            


        }

        [NonAction]
        //[Route("Current/Cancel")]
        [HttpPost]
        public ActionResult Cancel()
        {
            return RedirectToAction("index");
        }

        public ViewResult connection()
        {
            return View();
        }



    }
}