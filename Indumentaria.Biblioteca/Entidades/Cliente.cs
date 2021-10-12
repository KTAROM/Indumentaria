using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indumentaria.Biblioteca
{
    public class Cliente
    {
        private int _Codigo;
        private string _Apellido;
        private string _Nombre;

        public Cliente(int Codigo, string Apellido, string Nombre)
        {
            this._Codigo = Codigo;
            this._Apellido = Apellido;
            this._Nombre = Nombre;
        }


    }
}
