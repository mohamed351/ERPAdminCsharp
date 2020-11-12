using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ERPApplicationWebService.Models;

namespace ERPApplicationWebService.Controllers
{
    public class EmployeesController : ApiController
    {

        ERPWeb_WorldTransEntities db = new ERPWeb_WorldTransEntities();
        public IHttpActionResult Get(string name = "")
        {
            return Ok( db.Employees.Select(a => new { a.Employee_Name, a.Employee_NameA, a.Employee_ID})
                .Where(a=>a.Employee_Name.Contains(name)).OrderBy(a=>a.Employee_Name).Skip(0).Take(5).ToList());
        }


        public IHttpActionResult GetById([FromUri] int? ID)
        {
            if(ID == null)
                return BadRequest("The Bad Request");

            var employee = db.Employees.FirstOrDefault(a => a.Employee_ID == ID.Value);
            if (employee == null)
                return NotFound();

            return Ok(new { employee.Employee_Name , employee.Employee_NameA , employee.Employee_ID });
        }
    }
}
