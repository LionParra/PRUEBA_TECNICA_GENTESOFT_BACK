using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using ApiPrueba.Models.DBVehiculos;

namespace ApiPrueba.Controllers
{
    [RoutePrefix("informe")]
    public class InformeController : ApiController
    {
        [HttpGet]
        [Route("{tipo}")]
        public IHttpActionResult Informe(string tipo)
        {
            try {
                using (var db = new pruTecEntities())
                {
                    switch (tipo.ToUpper())
                    {
                        case "CARRO":
                            var listado = db.CARROS.GroupBy(x => x.MODELO).Select(group => new { 
                                Modelo = group.Key,
                                Valor = group.Sum(c => c.VALOR),
                                Cantidad = group.Count()
                            }).ToList();
                            return Ok(listado);

                        case "MOTO":
                            var listadom = db.MOTOS.GroupBy(x => x.MODELO).Select(grp => new { 
                                Modelo = grp.Key,
                                Valor = grp.Sum(g => g.VALOR),
                                Cantidad = grp.Count()
                            }).ToList();
                            return Ok(listadom);

                        default:
                            return BadRequest("El tipo de filtro referenciado no existe o no es valido, Recuerde enviar o carro o moto para el proceso");
                    }
                }
            }
            catch (Exception e) {
                return BadRequest("Ha ocurrido un error al generar el informe");
            }
        }
    }
}