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
using System.IO;

namespace Otimiza.Api.Controllers
{
    public class ImagensController : ApiController
    {
        private OtimizaDataContext db = new OtimizaDataContext();

        [HttpPut]
        [Route("api/FileUpload/{idVeiculo:int}")]
        public IHttpActionResult Upload(int idVeiculo)
        {
            int uploadCount = 0;
            string sPath = System.Web.Hosting.HostingEnvironment.MapPath("/Gallery/");

            System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;

            for (int i =0; i <files.Count; i++)
            {
                System.Web.HttpPostedFile file = files[i];

                string fileName = new FileInfo(file.FileName).Name;

                if (file.ContentLength > 0)
                {
                    Guid id = Guid.NewGuid();

                    string modifiedFileName = id.ToString() + "_" + fileName;

                    if (!File.Exists(sPath + Path.GetFileName(modifiedFileName)))
                    {
                        file.SaveAs(sPath + Path.GetFileName(modifiedFileName));
                        uploadCount++;

                        db.Imagens.Add(new Imagem() { FileName = "/Gallery/" + modifiedFileName, Title = fileName, VeiculoId = idVeiculo });
                    }
                }
            }
            if(uploadCount > 0)
            {
                db.SaveChanges();
                return Ok("Upload feito com Sucesso");
            }
            return InternalServerError();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: api/Imagens
        public IQueryable<Imagem> GetImagens()
        {
            return db.Imagens.Include("Veiculo");
        }
        // GET: api/Imagens/5
        [ResponseType(typeof(Imagem))]
        public IQueryable<Imagem> GetImagem(int id)
        {
            return db.Imagens.Where(x => x.VeiculoId == id);

        }

    }
}