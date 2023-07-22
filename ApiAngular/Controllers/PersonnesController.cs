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
using ApiAngular.Models;

namespace ApiAngular.Controllers
{
    public class PersonnesController : ApiController
    {
        private bdAngularContext db = new bdAngularContext();

        // GET: api/Personnes
        public IQueryable<Personnes> Getpersonnes()
        {
            return db.personnes;
        }

        // GET: api/Personnes/5
        [ResponseType(typeof(Personnes))]
        public IHttpActionResult GetPersonnes(int id)
        {
            Personnes personnes = db.personnes.Find(id);
            if (personnes == null)
            {
                return NotFound();
            }

            return Ok(personnes);
        }

        // PUT: api/Personnes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonnes(int id, Personnes personnes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personnes.Id)
            {
                return BadRequest();
            }

            db.Entry(personnes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonnesExists(id))
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

        // POST: api/Personnes
        [ResponseType(typeof(Personnes))]
        public IHttpActionResult PostPersonnes(Personnes personnes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.personnes.Add(personnes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personnes.Id }, personnes);
        }

        // DELETE: api/Personnes/5
        [ResponseType(typeof(Personnes))]
        public IHttpActionResult DeletePersonnes(int id)
        {
            Personnes personnes = db.personnes.Find(id);
            if (personnes == null)
            {
                return NotFound();
            }

            db.personnes.Remove(personnes);
            db.SaveChanges();

            return Ok(personnes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonnesExists(int id)
        {
            return db.personnes.Count(e => e.Id == id) > 0;
        }
    }
}