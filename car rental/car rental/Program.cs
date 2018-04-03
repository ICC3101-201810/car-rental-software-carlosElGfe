using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Arrendar> arriendos = new List<Arrendar>();
            List<Sucursal> sucursales = new List<Sucursal>();
            List<Cliente> clientes = new List<Cliente>();
           

            
            Console.WriteLine("Hola, bienvenido a la agencia de RENT A CAR SHILE, ingrese su opccion \n opcion 1 = agregar sucursal \n opcion 2 = agregar arriendo \n opcion 3 salir del programa");
            string opcion = Console.ReadLine();
            while (true)
                {
                if (opcion == "1")
                {
                    Console.WriteLine("ingrese nombre");
                     string nombre = Console.ReadLine();
                    Console.WriteLine("ingrese vehiculo por vehiculo y escriba listo para terminar");
                    List<Vehiculo> vehiculos_sucursal = new List<Vehiculo>();
                    string nombre_vehiculo = Console.ReadLine();
                    while (true)
                    {
                        if (nombre_vehiculo == "listo")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("ingrese  tipo de vehiculo");
                            string tipo = Console.ReadLine();
                            Vehiculo vehiculo = new Vehiculo(tipo);
                            vehiculos_sucursal.Add(vehiculo);
                        }
                    }
                    Console.WriteLine("añadir accesorios que posee la sucursal, y cuando este listo escriba listo");
                    string nombre_accesorio = Console.ReadLine();
                    List<Accesorio> accesorios_sucursal = new List<Accesorio>();
                    while (true)
                    {
                        if (nombre_accesorio == "listo")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("ingrese nombre del accesorio");
                            string nombre_accesorio1 = Console.ReadLine();
                            Accesorio accesorio_nuevo = new Accesorio(nombre_accesorio1);
                            accesorios_sucursal.Add(accesorio_nuevo);

                        }
                    }
                    
                    Sucursal sucursal = new Sucursal(vehiculos_sucursal,nombre,accesorios_sucursal);
                 }
                if (opcion == "2")
                {
                    Console.WriteLine("buscar o agregar clientes");
                    Console.WriteLine("ingrese nombre cliente :");
                    string posible_nombre = Console.ReadLine();
                    List<Accesorio> accesorios_elegidos_clientes = new List<Accesorio>();
                    foreach (Cliente cliente in clientes)
                    {
                        if( cliente.nombre == posible_nombre)
                        {
                            Console.WriteLine("cliente ya existe, elegir vehiculo ");
                            string eleccion_tipo_vehiculo = Console.ReadLine();
                            
                           
                            
                            foreach (Sucursal sucursal in sucursales)
                            {
                                Console.WriteLine("ingresar accesorio(s)");
                                foreach (Accesorio accesorio in sucursal.accesorios)
                                {
                           
                                    string eleccion_accesorio = Console.ReadLine();
                                    if (accesorio.nombre == eleccion_accesorio)
                                    {

                                        accesorios_elegidos_clientes.Add(accesorio);
                                    }
                                }
                                foreach (Vehiculo vehiculo  in sucursal.vehiculos)
                                {

                                    
                                        if (eleccion_tipo_vehiculo == vehiculo.tipo )

                                        {

                                            arriendos.Add(cliente.arrendar(sucursal, vehiculo, accesorios_elegidos_clientes));
                                        }
                                    
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("estamos trabajando para usted");
                        }
                    }
                }
                if (opcion == "3")
                {
                    Console.WriteLine("vuelva pronto");
                    break;

                }

                }
            Console.ReadKey();
        }
    }
}
