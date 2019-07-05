using PruebaTecnica.Logica;
using PruebaTecnica.Presentacion.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PruebaTecnica.Presentacion.Controllers
{
    public class ValueController : ApiController
    {
        //[Route("ObtenerSuma")]

        public long Get(int x, int y, int z){

            return new MetodosPrincipales().CantidadElementos(x, y, z);
        }

        public long Get(int x1, int y1, int z1, int x2, int y2, int z2) {

            return new MetodosPrincipales().Consulta(x1, y1,z1,x2,y2,z2);
        }


        public long[][][] Get(int x, int y, int z, int value)
        {
            return new MetodosPrincipales().Actualizar(x,y,z,value);
        }


        // POST: api/Value
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Value/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Value/5
        public void Delete(int id)
        {
        }
    }
}
