using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiPrueba.Models.DBVehiculos;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiPrueba.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("ventas")]
    public class VentasController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult Ventas()
        {
            try {
                using (var db = new pruTecEntities())
                {
                    var listado = db.VENTAS.ToList();
                    return Ok(listado);
                }
            }
            catch(Exception e)
            {
                return BadRequest("Ha ocurrido un error al ver el log de ventas");
            }
        }

    }
}