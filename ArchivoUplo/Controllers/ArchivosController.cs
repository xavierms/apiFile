using ArchivoUplo.Connections;
using ArchivoUplo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArchivoUplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivosController : ControllerBase
    {
        ImyConnect _imyConnect;
        public ArchivosController(ImyConnect imyConnect)
        {
            _imyConnect = imyConnect;
        }
        // GET: api/<ArchivosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ArchivosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ArchivosController>
        [HttpPost]
        public ActionResult PostArchivos([FromForm] List<IFormFile> files)
        {
            List<clsArchivo> archivos = new List<clsArchivo>();
            try
            {
                if (files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        var filePath = "C:\\Users\\xavie\\Desktop\\clsArchivo\\" + file.FileName;
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            file.CopyToAsync(stream);
                        }
                        double tamanio = file.Length;
                        tamanio = tamanio / 1000000;
                        tamanio = Math.Round(tamanio, 2);
                        clsArchivo archivo = new clsArchivo();
                        archivo.extension = Path.GetFileNameWithoutExtension(file.FileName);
                        archivo.tamanio = tamanio;
                        archivo.ubicacion = filePath;
                        archivos.Add(archivo);
                        _imyConnect.Añadir(archivo);
                    }

                    
                }
            }
            catch (Exception xx)
            {

                return BadRequest(xx.Message);
            }
            return Ok(archivos);
        }

        // PUT api/<ArchivosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArchivosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
