using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity.Migrations;
using System.Web;
using System.Web.Http;
using ApiPrueba.Models.DBVehiculos;
using System.Web.Http.Cors;

namespace ApiPrueba.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("vehiculos")]
    public class VehiculosController : ApiController
    {

        [HttpGet]
        [Route("get")]
        public IHttpActionResult GetAll()
        {
            try
            {
                using (var db = new pruTecEntities())
                {

                    var listado = db.CARROS.ToList();
                    return Ok(listado);
                }
            }
            catch (Exception e)
            {
                return BadRequest("error al validar");
            }

        }


        [HttpGet]
        [Route("get/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (var db = new pruTecEntities())
                {

                    var listado = db.CARROS.Where(X => X.Id == id).ToList();

                    if (listado.Count < 1)
                    {
                        return BadRequest("esta vacia para ese dato");
                    }
                    else
                    {
                        return Ok(listado);
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest("error al validar");
            }

        }


        [HttpPost]
        [Route("post")]
        public IHttpActionResult PostCarro(tipocar nuevo)
        {
            try
            {
                using (var db = new pruTecEntities())
                {
                    var listado = db.CARROS.ToList();
                    if (listado.Count < 10)
                    {
                        CARROS dato = new CARROS();
                        dato.MODELO = nuevo.MODELO;
                        dato.COLOR = nuevo.COLOR;
                        dato.KILOMETRAJE = nuevo.KILOMETRAJE;
                        dato.VALOR = nuevo.VALOR;
                        dato.IMAGEN = nuevo.IMAGEN;
                        dato.FECHA_REGISTRO = DateTime.Now;
                        dato.TIPO = nuevo.TIPO;

                        db.CARROS.Add(dato);
                        db.SaveChanges();

                        return Ok(true);
                    }
                    else
                    {
                        return BadRequest("Limite de carros almacenados alcanzado, realizar ventas para registrar el vehiculo");
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest("error al validar");
            }

        }

        [HttpPut]
        [Route("put/{id}")]
        public IHttpActionResult Put(int id, tipocar nuevo)
        {
            try
            {
                using (var db = new pruTecEntities())
                {
                    var dato = db.CARROS.Where(x => x.Id == id).FirstOrDefault();

                    dato.MODELO = nuevo.MODELO;
                    dato.COLOR = nuevo.COLOR;
                    dato.KILOMETRAJE = nuevo.KILOMETRAJE;
                    dato.VALOR = nuevo.VALOR;
                    dato.IMAGEN = nuevo.IMAGEN;
                    dato.TIPO = nuevo.TIPO;

                    db.CARROS.AddOrUpdate(dato);
                    db.SaveChanges();

                    return Ok(true);
                }
            }
            catch (Exception e)
            {
                return BadRequest("error al validar");
            }

        }

        [HttpDelete]
        [Route("del/{id}")]
        public IHttpActionResult Delete(int id, venta dato)
        {
            try
            {
                using (var db = new pruTecEntities())
                {
                    var buscado = db.CARROS.Where(x => x.Id == id).FirstOrDefault();

                    if (buscado == null)
                    {
                        return BadRequest("El dato a elimninar no existe en la db o ya fue eliminado");
                    }
                    else
                    {
                        VENTAS nuevo = new VENTAS();
                        nuevo.NOMBRE = dato.NOMBRE;
                        nuevo.DOCUMENTO = dato.DOCUMENTO;
                        nuevo.FECHA_REGISTRO = DateTime.Now;
                        db.VENTAS.Add(nuevo);

                        db.CARROS.Remove(buscado);
                        db.SaveChanges();
                        return Ok(true);
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest("error al validar");
            }

        }


    }

    public class venta {
        public string NOMBRE { get; set; }
        public string DOCUMENTO { get; set; }
    }

    public class tipocar
    {
        public string MODELO { get; set; }
        public string COLOR { get; set; }
        public int KILOMETRAJE { get; set; }
        public string TIPO { get; set; }
        public string IMAGEN { get; set; }
        public int VALOR { get; set; }
        public int VELOCIDADES { get; set; }
        public int CILINDRAJE { get; set; }
    }




}