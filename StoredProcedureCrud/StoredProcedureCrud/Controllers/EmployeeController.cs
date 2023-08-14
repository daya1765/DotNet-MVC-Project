using StoredProcedureCrud.DatabaseConnection;
using StoredProcedureCrud.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoredProcedureCrud.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult GetAllEmployees()
        {
           
            dotnetdb5Entities d4 = new dotnetdb5Entities();
            var res = d4.GetEmpl().ToList();
            return View(res);

        }


          public ActionResult Delete(int Id)
          {
            dotnetdb5Entities d5 = new dotnetdb5Entities();
              d5.DeleteEmploy(Id);

              d5.SaveChanges();
              return RedirectToAction("GetAllEmployees");
          }

        [HttpGet]
       public ActionResult AddEmp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmp(Emplo obj)
        {

            dotnetdb5Entities d5 = new dotnetdb5Entities();
          
            
            

            if (obj.Id==0)
            {


                d5.InsertEmploy(obj.Id, obj.EmpName, obj.EmpCompany, obj.EmpSalary, obj.EmpDepartment);
                d5.SaveChanges();
            }
            
            else
            
            {
               
                
                    var res = d5.UpdateEmploy(obj.Id, obj.EmpName, obj.EmpCompany, obj.EmpSalary, obj.EmpDepartment);
                    d5.SaveChanges();
                

            }

            return RedirectToAction("GetAllEmployees");

            


        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            dotnetdb5Entities d6 = new dotnetdb5Entities();
            var res = d6.Emploes.Where(m => m.Id == Id).FirstOrDefault();

            EmpModel em = new EmpModel();
            em.Id = res.Id;
            em.EmpName = res.EmpName;
            em.EmpCompany = res.EmpCompany;
            em.EmpSalary = res.EmpSalary;
            em.EmpDepartment = res.EmpDepartment;


          
            return View("AddEmp", res);
           


        }
    }
}