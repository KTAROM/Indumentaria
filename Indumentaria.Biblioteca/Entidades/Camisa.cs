using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indumentaria.Biblioteca.Entidades
{
    public class Camisa:Indumentaria1
    {
        private string _Manga;
        private bool _TieneEstampado;

        public Camisa(string Manga, bool Estamado, int Codigo): base(Codigo)
        {
            this._Manga = Manga; 
            this._TieneEstampado = Estamado;
           
        }
        public Camisa(int codigo): base(codigo)
        {

        }

  public override string GetDetalle()
        {
            string estampado = "";
            if(this._TieneEstampado)
            { estampado = "SI"; }
            else { estampado = "NO"; }
            string Detalle = "Prenda: CAMISA" + "\nTipo de manga: " + this._Manga + "\nEstampado: " + estampado + "\nTalle: " + this.Talle + " Cantidad Stock: " + this.Stock +
            " Precio: " + this.Precio;
            return Detalle;
        }
    }
}
