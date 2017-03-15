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
using API.Models;
using BankSystem.Models;

namespace API.Controllers
{
    public class CobroDocumentosController : ApiController
    {
        private APIContext db = new APIContext();

        // GET: api/CobroDocumentos
        public IQueryable<CobroDocumento> GetCobroDocumentoes()
        {
            return db.CobroDocumentoes;
        }

        // GET: api/CobroDocumentos/5
        [ResponseType(typeof(CobroDocumento))]
        public IHttpActionResult GetCobroDocumento(int id)
        {
            CobroDocumento cobroDocumento = db.CobroDocumentoes.Find(id);
            if (cobroDocumento == null)
            {
                return NotFound();
            }

            return Ok(cobroDocumento);
        }

        // PUT: api/CobroDocumentos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCobroDocumento(int id, CobroDocumento cobroDocumento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cobroDocumento.IdCobroDocumento)
            {
                return BadRequest();
            }

            db.Entry(cobroDocumento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CobroDocumentoExists(id))
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

        // POST: api/CobroDocumentos
        [ResponseType(typeof(CobroDocumento))]
        public IHttpActionResult PostCobroDocumento(CobroDocumento cobroDocumento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CobroDocumentoes.Add(cobroDocumento);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cobroDocumento.IdCobroDocumento }, cobroDocumento);
        }

        // DELETE: api/CobroDocumentos/5
        [ResponseType(typeof(CobroDocumento))]
        public IHttpActionResult DeleteCobroDocumento(int id)
        {
            CobroDocumento cobroDocumento = db.CobroDocumentoes.Find(id);
            if (cobroDocumento == null)
            {
                return NotFound();
            }

            db.CobroDocumentoes.Remove(cobroDocumento);
            db.SaveChanges();

            return Ok(cobroDocumento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CobroDocumentoExists(int id)
        {
            return db.CobroDocumentoes.Count(e => e.IdCobroDocumento == id) > 0;
        }
    }
}