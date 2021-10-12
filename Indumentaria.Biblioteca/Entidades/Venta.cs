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

        public Venta()
        {
            Cliente Cliente1 = new Cliente(1, "Perez", "Raul");
            
        }

       public double GetTotalPedido()
        {
            double TotalPedido = 0;
            return TotalPedido;
        }
    }
}
