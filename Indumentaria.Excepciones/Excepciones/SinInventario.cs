using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indumentaria.Excepciones
{
    public class SinInventario : Exception
    {
        public SinInventario(string msj) : base(msj)
        {
            Console.WriteLine(msj);
        }
    }
   
}
