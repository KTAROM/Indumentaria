using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indumentaria.Biblioteca.Entidades
{
   public class IndumentariaDeportiva: TipoIndumentaria
    {
        public IndumentariaDeportiva(string Origen, double porcentaje) : base(Origen, porcentaje)
        { }
    }
}
