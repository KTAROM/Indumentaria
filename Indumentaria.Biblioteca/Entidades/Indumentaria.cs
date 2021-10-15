using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indumentaria.Biblioteca.Entidades
{
    public abstract class Indumentaria1
    {
        private TipoIndumentaria _Tipo;
        private int _Codigo;
        private int _Stock;
        private string _Talle;
        private double _Precio;

        public int Codigo
        {
            get { return this._Codigo; }
        }
        
        public int Stock
        {
            get { return _Stock; }
            set { _Stock = value; }
        }
        public TipoIndumentaria Tipo
        {
            set { _Tipo = value; }
        }
          public double Precio
        {
            get { return this._Precio; }
            set { this._Precio = value; }
        }
        public string Talle
        {
            get { return this._Talle; }
            set { this._Talle = value; }
        }
        public Indumentaria1(TipoIndumentaria Tipo, int Codigo, string Talle, double Precio, int Stock = 3)
        {
            this._Tipo = Tipo;
            this._Codigo = Codigo;
            this._Stock = Stock;
            this._Talle = Talle;
            this._Precio = Precio;
        }

        public Indumentaria1 (int Codigo)
        {
            this._Stock = 3;
            this._Codigo = Codigo;
        }

        
        public override string ToString()
        {
            string detalle;

            detalle = "Código de Prenda: " + this._Codigo;
            return detalle;
        }

       public override bool Equals(object obj)
        {
           if(obj!=null && obj is Indumentaria1)
            {
                int codigo = 0;
                Indumentaria1 prenda1 = new Camisa(codigo);
                try
                {
                    prenda1 = (Camisa)obj;
                }
                catch { prenda1 = (Pantalon)obj; }

                if (this.Codigo == prenda1.Codigo)
                { return true; }
                
               
            }
            return false;
        }
       
      
        public abstract string GetDetalle();
        
    }
}
