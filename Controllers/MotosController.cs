using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiPrueba.Models.DBVehiculos;
using System.Web.Http;
using System.Data.Entity.Migrations;
using System.Web.Http.Cors;

namespace ApiPrueba.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("motos")]
    public class MotosController : ApiController
    {

        [HttpGet]
        [Route("get")]
        public IHttpActionResult GetAllMotos()
        {
            try
            {
                using (var db = new pruTecEntities())
                {

                    var listado = db.MOTOS.ToList();
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
        public IHttpActionResult GetMoto(int id)
        {
            try
            {
                using (var db = new pruTecEntities())
                {

                    var listado = db.MOTOS.Where(X => X.Id == id).ToList();

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
        public IHttpActionResult PostMoto(tipocar nuevo)
        {
            try
            {
                using (var db = new pruTecEntities())
                {
                    var listado = db.MOTOS.ToList();
                    if (listado.Count < 15)
                    {
                        MOTOS dato = new MOTOS();
                        dato.MODELO = nuevo.MODELO;
                        dato.COLOR = nuevo.COLOR;
                        dato.KILOMETRAJE = nuevo.KILOMETRAJE;
                        dato.VALOR = nuevo.VALOR;
                        dato.IMAGEN = nuevo.IMAGEN;
                        dato.FECHA_REGISTRO = DateTime.Now;
                        dato.TIPO = nuevo.TIPO;
                        dato.VELOCIDADES = nuevo.VELOCIDADES;
                        dato.CILINDRAJE = nuevo.CILINDRAJE;

                        db.MOTOS.Add(dato);
                        db.SaveChanges();

                        return Ok(true);
                    }
                    else
                    {
                        return BadRequest("Limite de motos almacenadas alcanzado, realizar ventas para registrar el vehiculo");
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
                    var dato = db.MOTOS.Where(x => x.Id == id).FirstOrDefault();

                    dato.MODELO = nuevo.MODELO;
                    dato.COLOR = nuevo.COLOR;
                    dato.KILOMETRAJE = nuevo.KILOMETRAJE;
                    dato.VALOR = nuevo.VALOR;
                    dato.IMAGEN = nuevo.IMAGEN;
                    dato.TIPO = nuevo.TIPO;
                    dato.VELOCIDADES = nuevo.VELOCIDADES;
                    dato.CILINDRAJE = nuevo.CILINDRAJE;

                    db.MOTOS.AddOrUpdate(dato);
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
                    var buscado = db.MOTOS.Where(x => x.Id == id).FirstOrDefault();

                    if (buscado == null)
                    {
                        return BadRequest("El dato a elimninar no existe en la db o ya fue vendido");
                    }
                    else
                    {
                        VENTAS nuevo = new VENTAS();
                        nuevo.NOMBRE = dato.NOMBRE;
                        nuevo.DOCUMENTO = dato.DOCUMENTO;
                        nuevo.FECHA_REGISTRO = DateTime.Now;
                        db.VENTAS.Add(nuevo);

                        db.MOTOS.Remove(buscado);
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
}