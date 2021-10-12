using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indumentaria.Biblioteca.Entidades
{
    public class Pantalon:Indumentaria1
    {
        private string _Material;
        private bool _TieneBolsillos;

        public Pantalon (string Material, bool Bolsillos, int Codigo): base (Codigo)
        {
            this._Material = Material;
            this._TieneBolsillos = Bolsillos;
        }
        
        public override string GetDetalle()
        {
            string bolsillos = "";
            if(this._TieneBolsillos)
            { bolsillos = "SI"; }
            else { bolsillos = "NO"; }
            string Detalle = "Prenda: PANTALON" + "\nTipo de material: " + this._Material + "\nPosee bolsillos: " + bolsillos;
            return Detalle;

        }
    }
}
