using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indumentaria.Excepciones.Excepciones;
using Indumentaria.Excepciones;

namespace Indumentaria.Biblioteca.Entidades
{
    public class TiendaRopa
    {
        private List<Indumentaria1> _Inventario;
        private List<Venta> _Ventas;
        private int _ultimoCodigo;


       
        public TiendaRopa()
        {

            this._Ventas = new List<Venta>();
        }

        public int GetProximoCodigo()
        {
            this._ultimoCodigo += 1;
           
            return this._ultimoCodigo;
        }

        public void Agregar(Indumentaria1 Ropa)
        {
            if(this._Inventario==null)
            {
                this._Inventario = new List<Indumentaria1>();
            }
            this._Inventario.Add(Ropa);

        }

        public void Modificar(Indumentaria1 Ropa)
        {

        }

        public void Quitar(Indumentaria1 Ropa)
        {
            this._Inventario.Remove(Ropa);
        }

        public void IngresarOrden(Venta Orden)
        {
            this._Ventas.Add(Orden);

        }

        public List<Venta> ListarOrden()
        {
            if (this._Ventas == null)
            {
                throw new SinVentas("Aún no se han ingresado Ordenes");
            }
            if (this._Ventas.Count() == 0)
            {
                throw new SinVentas("No hay Ordenes ingresadas");
            }

            return _Ventas;
        }

        public List<Indumentaria1> Listar()
        {
            if(this._Inventario==null)
            {
                throw new SinInventario("Aún no hay prendas en el Stock");
            }
            if(this._Inventario.Count()==0)
            {
                throw new SinInventario("No hay prendas en Stock");
            }


            return _Inventario;
        }

        public void DevolverOrden(Venta Orden)
        {

            _Ventas.Remove(Orden);
        }

    }
}
