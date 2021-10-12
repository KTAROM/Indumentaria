using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indumentaria.Biblioteca.Entidades;
using Indumentaria.Excepciones;
using Indumentaria.Utils;

   

namespace Indumentaria.Consola
{
    
    class Program
    {
       

        static void Main(string[] args)

        {
            TiendaRopa NuevaTienda = new TiendaRopa();
            bool estado = true;
            do
            {
                Console.Clear();
                estado = true;
                DesplegarMenu();
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        ListarIndumentaria(NuevaTienda);
                        break;
                    case "2":
                        AgregarIndumentaria(NuevaTienda);
                        break;
                    case "3":
                        break;
                    case "4":
                        EliminarPrenda(NuevaTienda);
                        break;
                    case "5":
                        break;
                    case "6":
                        IngresarOrden(NuevaTienda);
                        break;
                    case "7":
                        break;
                    case "8":
                        estado = false;
                        break;
                    default:
                        Console.WriteLine("El valor ingresado es incorrecto, intente nuevamente");
                        break;

                }
            } while (estado);
        }

        public static void DesplegarMenu()
        {
            Console.WriteLine(
                "1- Listar Indumentaria\n" +
                "2- Agregar Indumentaria\n" +
                "3- Modificar Indumentaria\n" +
                "4- Eliminar Indumentaria\n" +
                "5- Listar ordenes\n" +
                "6- Ingresar orden\n" +
                "7- Devolver orden\n" +
                "8- Salir");

        }
        public static void ListarIndumentaria(TiendaRopa NuevaTienda)
        {
            List<Indumentaria1> Inventario = new List<Indumentaria1>();
            try
            {
               Inventario = NuevaTienda.Listar();
            }

            catch (SinInventario ex)
            {
                
            }
           foreach(Indumentaria1 prenda in Inventario)
            {
                Console.WriteLine(prenda.GetDetalle());
            }
            Console.ReadKey();
        }
        public static void AgregarIndumentaria(TiendaRopa NuevaTienda)
        {
            Console.Clear();
            Console.WriteLine("Ingrese el tipo de prenda que desea agregar a Stock:");

          AgregarPrenda(NuevaTienda);
           
        }
        public static void MostrarPrendas()
        {
            string[] TipoPrenda = Enum.GetNames(typeof(TipoPrenda));
            foreach( var name in TipoPrenda)
            {
                Console.WriteLine(name);
            }

        }
        public static void MostrarTipos()
        {
            string[] TipoRopa = Enum.GetNames(typeof(TipoRopa));
            foreach (var name in TipoRopa)
            {
                Console.WriteLine(name);
            }

        }

        public static void AgregarPrenda(TiendaRopa NuevaTienda)
        {
         
            MostrarPrendas();
           
            string tipo = Console.ReadLine().ToLower();
            TipoPrenda tipoPrenda = TipoPrenda.pantalon;


            if (tipo == TipoPrenda.camisa.ToString() )
            {
                Console.WriteLine("Usted seleccionó agregar una camisa");
                Console.ReadKey();
                tipoPrenda = TipoPrenda.camisa;
                CrearCamisa(NuevaTienda);
               

            }
            else if (tipo == TipoPrenda.pantalon.ToString())
            {
                Console.WriteLine("Usted seleccionó agregar un pantalón");
                Console.ReadKey();
                CrearPantalon(NuevaTienda);
            }
            else
            {
                Console.WriteLine("El valor Ingresado es incorrecto");
                Console.ReadKey();
              
            }
         

        }

        public static void AgregarTipo(TiendaRopa NuevaTienda, Indumentaria1 Prenda)
        {
            Console.Clear();
            bool estado = true;
            Console.WriteLine("Ingrese el tipo de indumentaria:");

            MostrarTipos();

            string tipo = Console.ReadLine().ToLower();
            if (tipo != TipoRopa.casual.ToString() && tipo != TipoRopa.deportiva.ToString() && 
                tipo != TipoRopa.formal.ToString())
            {
                Console.WriteLine("El valor Ingresado es incorrecto");
                Console.ReadKey();
                estado = false;
            }
            if (estado)
            {
                TipoRopa tipoRopa = TipoRopa.formal;
                string origen = ConsolaUtils.PedirNombre("Indique el origen de la prenda");

                double porcentaje = ConsolaUtils.PedirDouble("Indique el porcentaje de algodón que posee la prenda");

                if (tipo == TipoRopa.casual.ToString())
                {
                    tipoRopa = TipoRopa.casual;
                    TipoIndumentaria Tipo = new IndumetariaCasual(origen, porcentaje);
                    Prenda.Tipo = Tipo;

                }
                else if (tipo == TipoRopa.deportiva.ToString())
                {
                    tipoRopa = TipoRopa.deportiva;
                    TipoIndumentaria Tipo = new IndumentariaDeportiva(origen, porcentaje);
                    Prenda.Tipo = Tipo;
                }
                else if (tipo == TipoRopa.formal.ToString())
                {
                    tipoRopa = TipoRopa.formal;
                    TipoIndumentaria Tipo = new IndumentariaFormal(origen, porcentaje);
                    Prenda.Tipo = Tipo;
                }
            }
        
        }

        public static void CrearCamisa(TiendaRopa NuevaTienda)
        {
            Console.Clear();
            Console.WriteLine("Indique el tipo de manga");
            string manga = Console.ReadLine();
            bool respuesta;
            string estampado;
            do
            {
                Console.WriteLine("Indique si posee estampado (S/N)");
                estampado = Console.ReadLine();
               respuesta = ConsolaUtils.SoN(estampado);
                if (!respuesta)
                {
                    ConsolaUtils.MsjErr();
                }
            } while (!respuesta);
           
            if(estampado.ToUpper()=="N")
            { respuesta = false; }
            int codigo = NuevaTienda.GetProximoCodigo();
           
            Indumentaria1 Prenda = new Camisa(manga, respuesta,codigo);           
            AgregarTipo(NuevaTienda, Prenda);
            Modificar(NuevaTienda, Prenda);
            NuevaTienda.Agregar(Prenda);
        }
        public static void CrearPantalon(TiendaRopa NuevaTienda)
        {
            Console.Clear();
            Console.WriteLine("Indique el tipo de material");
            string material = Console.ReadLine();
            bool respuesta;
            string bolsillos;
            do
            {
                Console.WriteLine("Indique si posee bolsillos (S/N)");
                bolsillos = Console.ReadLine();
                respuesta = ConsolaUtils.SoN(bolsillos);
                if (!respuesta)
                {
                    ConsolaUtils.MsjErr();
                }
            } while (!respuesta);
           
            if (bolsillos.ToUpper() == "N")
            { respuesta = false; }

            int codigo = NuevaTienda.GetProximoCodigo();
            Indumentaria1 Prenda = new Pantalon(material, respuesta,codigo);
            AgregarTipo(NuevaTienda, Prenda);
            Modificar(NuevaTienda, Prenda);
            NuevaTienda.Agregar(Prenda);
        }

        public static void EliminarPrenda(TiendaRopa NuevaTienda)
        {
            Console.Clear();
            try
            {
                Console.WriteLine("LISTADO DE PRENDAS:");
                List<Indumentaria1> Inventario = NuevaTienda.Listar();
                foreach (Indumentaria1 prenda in Inventario)
                {
                    Console.WriteLine(prenda.ToString());
                    Console.WriteLine(prenda.GetDetalle());
                }
                int codigo = ConsolaUtils.PedirInt("Indique el código de la prenda que desea eliminar");
                Indumentaria1 prenda1 = new Camisa(codigo);

                foreach (Indumentaria1 prenda in Inventario)
                {
                    if (prenda.Equals(prenda1))
                    {
                        prenda1 = prenda;
                    }
                }
                NuevaTienda.Quitar(prenda1);
                Console.WriteLine("La prenda fue eliminada");
            }
            catch(SinInventario ex)
            {
                Console.ReadKey();
            }
         

        }
        public static void IngresarOrden(TiendaRopa NuevaTienda)
        {           
            EstadoVenta EstadoOrden = 0;
            try
            {
                do
                {
                    Console.Clear();

                    string mensaje = ("Ingrese el código de la prenda que desea agregar a su orden");
                    List<Indumentaria1> Inventario = NuevaTienda.Listar();
                    Indumentaria1 prenda = BuscarPrenda(Inventario, mensaje);
                    int cantidad = ConsolaUtils.PedirInt("Ingrese la cantidad que desea");
                    if (prenda.Stock < cantidad)
                    {
                        Console.WriteLine("No hay suficientes prendas en stock");
                        EstadoOrden = EstadoVenta.Procesada;
                        Console.ReadLine();
                    }
                    else
                    {
                        VentaItem Orden = new VentaItem(cantidad, prenda);
                        Console.WriteLine("Se ingreso el item a su orden");
                    }     
                    bool estado;
                    do
                        {
                            estado = true;
                            string opcion = ConsolaUtils.PedirNombre("Si desea ingresar otra prenda " +
                            "ingrese S o N para terminar");
                            if (ConsolaUtils.SoN(opcion))
                            {
                                if (opcion.ToUpper() == "N")
                                {
                                    EstadoOrden = EstadoVenta.Procesada;
                                }
                            }
                            else
                            {
                                ConsolaUtils.MsjErr();
                                estado = false;

                            }
                        } while (!estado);
                    

                } while (EstadoOrden == 0);
            }
            catch (SinInventario ex)
            {
                Console.ReadKey();
            }



        }

        public static TipoPrenda IndicarPrenda(string tipo)
        {
           TipoPrenda tipoPrenda = TipoPrenda.pantalon;

            if (tipo == TipoPrenda.camisa.ToString())
            {
                Console.WriteLine("Usted seleccionó una camisa");
                Console.ReadKey();
                tipoPrenda = TipoPrenda.camisa;

            }

            else { Console.WriteLine("Usted seleccionó un pantalón"); }
            return tipoPrenda;
        }

        public static Indumentaria1 BuscarPrenda(List<Indumentaria1> Inventario,string mensaje)
        {
            foreach (Indumentaria1 prenda in Inventario)
            {
                Console.WriteLine(prenda.ToString());
                Console.WriteLine(prenda.GetDetalle());
            }
            int codigo = ConsolaUtils.PedirInt(mensaje);
            Indumentaria1 prenda1 = new Camisa(codigo);

            foreach (Indumentaria1 prenda in Inventario)
            {
                if (prenda.Equals(prenda1))
                {
                    prenda1 = prenda;
                }
            }
            return prenda1;
        }

        public static void Modificar(TiendaRopa NuevaTienda, Indumentaria1 Prenda)
        {

            int cantidad = ConsolaUtils.PedirInt("Ingrese la cantidad de prendas");
            Prenda.Stock = cantidad;
            string talle = ConsolaUtils.PedirNombre("Indique el talle de la prenda");
            Prenda.Talle = talle;
            double precio = ConsolaUtils.PedirDouble("Indique el precio de la prenda");
            Prenda.Precio = precio;
        }
    }
}

