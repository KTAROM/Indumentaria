using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indumentaria.Biblioteca.Entidades
{
    public class IndumentariaFormal: TipoIndumentaria
    {
        public IndumentariaFormal(string Origen, double porcentaje) : base(Origen, porcentaje)
        { }
    }
}
