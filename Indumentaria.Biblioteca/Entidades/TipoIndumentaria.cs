using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indumentaria.Biblioteca.Entidades
{
    public abstract class TipoIndumentaria
    {
        private string _Origen;
        private double _PorcentajeAlgodon;

        public string Origen
        {
            get { return this._Origen; }
        }
        public double Porcentaje
        {
            get { return this._PorcentajeAlgodon; }
        }
            

        public TipoIndumentaria(string Origen, double Porcentaje)
        {
            this._Origen = Origen;
            this._PorcentajeAlgodon = Porcentaje;
        }

        public TipoIndumentaria()
        {

        }


    }
}
