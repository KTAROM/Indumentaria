using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indumentaria.Biblioteca.Entidades
{
   public class Venta
    {
        private List<VentaItem> _Items;
        private Cliente _Cliente;
        private int _Estado;
        private int _Codigo;


        public List<VentaItem> Ordenes
        {
            get { return this._Items; }
            set { this._Items = value; }
        }
        public int Codigo
        {
            set { this._Codigo = value; }
            get { return this._Codigo; }
        }
        public Cliente Cliente
        {
            get { return this._Cliente; }
        }
        public Venta()
        {
            Cliente Cliente1 = new Cliente(1, "Perez", "Raul");
            
        }

       public double GetTotalPedido()
        {

            double TotalPedido = 0;
            foreach(VentaItem Orden in _Items)
            {
                TotalPedido += Orden.GetTotal();
            }
            return TotalPedido;
        }
    }
}
