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
    public class ContactGroupsController : ApiController
    {
        private ERPWeb_WorldTransEntities db = new ERPWeb_WorldTransEntities();

        // GET: api/ContactGroups
        public IQueryable<ContactGroup> GetContactGroups()
        {
            return db.ContactGroups;
        }

        // GET: api/ContactGroups/5
        [ResponseType(typeof(ContactGroup))]
        public IHttpActionResult GetContactGroup(int id)
        {
            ContactGroup contactGroup = db.ContactGroups.Find(id);
            if (contactGroup == null)
            {
                return NotFound();
            }

            return Ok(contactGroup);
        }

        // PUT: api/ContactGroups/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContactGroup(int id, ContactGroup contactGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactGroup.ContactGroup_ID)
            {
                return BadRequest();
            }

            db.Entry(contactGroup).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactGroupExists(id))
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

        // POST: api/ContactGroups
        [ResponseType(typeof(ContactGroup))]
        public IHttpActionResult PostContactGroup(ContactGroup contactGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ContactGroups.Add(contactGroup);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contactGroup.ContactGroup_ID }, contactGroup);
        }

        // DELETE: api/ContactGroups/5
        [ResponseType(typeof(ContactGroup))]
        public IHttpActionResult DeleteContactGroup(int id)
        {
            ContactGroup contactGroup = db.ContactGroups.Find(id);
            if (contactGroup == null)
            {
                return NotFound();
            }

            db.ContactGroups.Remove(contactGroup);
            db.SaveChanges();

            return Ok(contactGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactGroupExists(int id)
        {
            return db.ContactGroups.Count(e => e.ContactGroup_ID == id) > 0;
        }
    }
}