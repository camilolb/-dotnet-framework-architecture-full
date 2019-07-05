using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Servicios
{
    class Program
    {
        static void Main(string[] args)
        {
            Servicio.ndfdXMLPortTypeClient PruebaConcepto = new Servicio.ndfdXMLPortTypeClient();
            var resultado = PruebaConcepto.LatLonListCityNames("Oklahoma");

        }
    }
}
