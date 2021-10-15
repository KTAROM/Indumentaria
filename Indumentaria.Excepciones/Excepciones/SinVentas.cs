using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indumentaria.Excepciones.Excepciones
{
    public class SinVentas : Exception
    {
        public SinVentas(string msj) : base(msj)
        {
            Console.WriteLine(msj);
        }
    }
}
