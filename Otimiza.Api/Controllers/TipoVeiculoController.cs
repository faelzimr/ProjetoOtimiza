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
using Otimiza.Domain;
using Otimiza.Infra.DataContexts;

namespace Otimiza.Api.Controllers
{
    public class TipoVeiculoController : ApiController
    {
        private OtimizaDataContext db = new OtimizaDataContext();

        // GET: api/TipoVeiculo
        public IQueryable<TipoVeiculo> GetTipoVeiculos()
        {
            return db.TipoVeiculos;
        }

        // GET: api/TipoVeiculo/5
        [ResponseType(typeof(TipoVeiculo))]
        public IHttpActionResult GetTipoVeiculo(int id)
        {
            TipoVeiculo tipoVeiculo = db.TipoVeiculos.Find(id);
            if (tipoVeiculo == null)
            {
                return NotFound();
            }

            return Ok(tipoVeiculo);
        }

        // PUT: api/TipoVeiculo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoVeiculo(int id, TipoVeiculo tipoVeiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoVeiculo.Id)
            {
                return BadRequest();
            }

            db.Entry(tipoVeiculo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoVeiculoExists(id))
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

        // POST: api/TipoVeiculo
        [ResponseType(typeof(TipoVeiculo))]
        public IHttpActionResult PostTipoVeiculo(TipoVeiculo tipoVeiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoVeiculos.Add(tipoVeiculo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoVeiculo.Id }, tipoVeiculo);
        }

        // DELETE: api/TipoVeiculo/5
        [ResponseType(typeof(TipoVeiculo))]
        public IHttpActionResult DeleteTipoVeiculo(int id)
        {
            TipoVeiculo tipoVeiculo = db.TipoVeiculos.Find(id);
            if (tipoVeiculo == null)
            {
                return NotFound();
            }

            db.TipoVeiculos.Remove(tipoVeiculo);
            db.SaveChanges();

            return Ok(tipoVeiculo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoVeiculoExists(int id)
        {
            return db.TipoVeiculos.Count(e => e.Id == id) > 0;
        }
    }
}