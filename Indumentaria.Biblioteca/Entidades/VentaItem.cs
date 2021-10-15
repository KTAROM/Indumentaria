using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indumentaria.Biblioteca.Entidades
{
    public class VentaItem
    {
        private Indumentaria1 _Prenda;
        private int _Cantidad;

        public VentaItem(int Cantidad, Indumentaria1 Prenda)
        {
            this._Cantidad = Cantidad;
            this._Prenda = Prenda;
        }

        public Indumentaria1 Prenda
        {
            get { return this._Prenda; }
        }
        public int Cantidad
        {
            get { return this._Cantidad; }

        }

        public double GetTotal()
        {
            double Total = _Prenda.Precio * this._Cantidad;
            return Total;
        }
    }
}
