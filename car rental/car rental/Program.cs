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
            CarRental carRental = new CarRental(arriendos,sucursales,clientes);



            Console.WriteLine("Hola, bienvenido a la agencia de RENT A CAR SHILE");
            while (true)
                {
                Console.WriteLine(" ingrese su opccion \n opcion 1 = agregar sucursal \n opcion 2 = agregar arriendo \n opcion 3 salir del programa"); 
                string opcion = Console.ReadLine();
                if (opcion == "1")
                {

                    carRental.agregar_sucursal();
                    
                 }
                if (opcion == "2")
                {
                    Console.WriteLine("ingresar nombre cliente");
                    string nombre = Console.ReadLine();
                    if (carRental.reconocerCliente(nombre))
                    {
                        carRental.agregarCliente(nombre);
                    }
                    Console.WriteLine("ingresar tipo de vehiculo");
                    string tipo = Console.ReadLine();
                    if (carRental.reconocerVehiculoEyE(tipo))
                    {
                        carRental.crearArriendo(tipo, nombre);
                    }
                    Console.WriteLine("no hay de esos vehiculos");
                
                }
                if (opcion == "3")
                {
                    Console.WriteLine("vuelva pronto");
                    break;

                }
                else
                {
                    Console.WriteLine("opcion ingresada no valida");
                }

                }
            Console.ReadKey();
        }
    }
}
