using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ERPApplicationWebService.Models;

namespace ERPApplicationWebService.Controllers
{
    public class AcctsController : ApiController
    {
        private ERPWeb_WorldTransEntities db = new ERPWeb_WorldTransEntities();

        // GET: api/Acct
        public IHttpActionResult GetAccts()
        {
            return  Ok(db.Accts.Select(a => new { ID = a.id, AccID = a.AccID, a.AccName,AccNameE = a.AccNameE }).ToList());
        }

        // GET: api/Accts/5
        [ResponseType(typeof(Acct))]
        public IHttpActionResult GetAcct(int id)
        {
            Acct acct = db.Accts.Find(id);
            if (acct == null)
            {
                return NotFound();
            }

            return Ok(acct);
        }

        // PUT: api/Accts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAcct(int id, Acct acct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != acct.id)
            {
                return BadRequest();
            }

            db.Entry(acct).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcctExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Accts
        [ResponseType(typeof(Acct))]
        public IHttpActionResult PostAcct(Acct acct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Accts.Add(acct);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = acct.id }, acct);
        }

        // DELETE: api/Accts/5
        [ResponseType(typeof(Acct))]
        public IHttpActionResult DeleteAcct(int id)
        {
            Acct acct = db.Accts.Find(id);
            if (acct == null)
            {
                return NotFound();
            }

            db.Accts.Remove(acct);
            db.SaveChanges();

            return Ok(acct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AcctExists(int id)
        {
            return db.Accts.Count(e => e.id == id) > 0;
        }
    }
}