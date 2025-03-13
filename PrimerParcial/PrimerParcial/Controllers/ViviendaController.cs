using PrimerParcial.Clases;
using PrimerParcial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PrimerParcial.Controllers
{
    [RoutePrefix("api/Vivienda")]
    public class ViviendaController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<tblVivienda> ConsultarTodos()
        {
            clsVivienda vivienda = new clsVivienda();
            return vivienda.ConsultarTodasLasViviendas();
        }

        [HttpGet]
        [Route("ConsultarXID")]
        public tblVivienda ConsultarXID(string Id)
        {
            clsVivienda vivienda = new clsVivienda();
            return vivienda.ConsultarXID(Id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] tblVivienda viv)
        {
            clsVivienda clsVivienda = new clsVivienda();
            clsVivienda.vivienda = viv;
            return clsVivienda.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] tblVivienda viv)
        {
            clsVivienda clsVivienda = new clsVivienda();
            clsVivienda.vivienda = viv;
            return clsVivienda.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] tblVivienda viv)
        {
            clsVivienda clsVivienda = new clsVivienda();
            clsVivienda.vivienda = viv;
            return clsVivienda.Eliminar();
        }
    }
}