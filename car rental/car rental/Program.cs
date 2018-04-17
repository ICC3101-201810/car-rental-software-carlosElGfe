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
                string msg2 = " ingrese su opccion \n opcion 1 = agregar sucursal \n opcion 2 = agregar arriendo \n opcion 3 = simular dia sucursal \n opcion 4 = mostrar sucursales \n opcion 5 = mostras vehiculos en sucursal \n opcion 7 = crear arriendo \n opcion 8 = recibir vehiculo \n opcion 6 = salir del programa";
                carRental.Confirmation2(msg2);
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
                    List<Cliente> clientess = new List<Cliente>();
                    for (int i = 0; i < 150; i++)
                    {
                        if (i <=60)
                        {
                            Cliente clientee = new Cliente("persona", i.ToString());
                            clientess.Add(clientee);
                        }
                        else
                        {
                            Cliente clientee = new Cliente("empresa", i.ToString());
                            clientess.Add(clientee);
                        }
                        
                    }
                    List<string> libreta = new List<string>();
                    List<Vehiculo> autillos = new List<Vehiculo>();
                    List<Accesorio> accesorillos = new List<Accesorio>();
                    Vehiculo auto = new Vehiculo("autos", 15);
                    Vehiculo camio = new Vehiculo("camioneta", 18);
                    Vehiculo acuatico = new Vehiculo("acuatico", 9);
                    Vehiculo bus = new Vehiculo("bus", 4);
                    Vehiculo excabadoras = new Vehiculo("retro excabadora",3);
                    Vehiculo moto = new Vehiculo("moto", 14);
                    autillos.Add(auto);
                    autillos.Add(camio);
                    autillos.Add(bus);
                    autillos.Add(excabadoras);
                    autillos.Add(moto);
                    autillos.Add(acuatico);
                    Sucursal sucursalita = new Sucursal(autillos,"sucursal simulada",accesorillos);
                    for (int i = 0; i <= 11; i++)
                    {
                        Random random = new Random();
                        int compras;
                        compras = random.Next(5, 13);
                        for (int p = 0; p < compras; p++)
                        {
                            int elecion;
                            elecion = random.Next(1, 5);
                            if (elecion == 1)
                            {
                                foreach (Vehiculo vehiculo in sucursalita.vehiculos )
                                {
                                    if (vehiculo.stock>0 && vehiculo.tipo == "auto")
                                    {
                                        int numero = random.Next(1, 150);
                                        libreta.Add("se arrendo al cliente " + clientess[numero].nombre + " el vehiculo " + vehiculo.tipo);
                                        vehiculo.stock = vehiculo.stock - 1;
                                        break;
                                    }
                                    
                                }
                            }
                            if (elecion == 2)
                            {
                                foreach (Vehiculo vehiculo in sucursalita.vehiculos)
                                {
                                    if (vehiculo.stock > 0 && vehiculo.tipo == "camioneta")
                                    {
                                        int numero = random.Next(1, 150);
                                        libreta.Add("se arrendo al cliente " + clientess[numero].nombre + " el vehiculo " + vehiculo.tipo);
                                        vehiculo.stock = vehiculo.stock - 1;
                                        break;
                                    }

                                }
                            }
                            if (elecion == 3)
                            {
                                foreach (Vehiculo vehiculo in sucursalita.vehiculos)
                                {
                                    if (vehiculo.stock > 0 && vehiculo.tipo == "acuatico")
                                    {
                                        int numero = random.Next(1, 150);
                                        libreta.Add("se arrendo al cliente " + clientess[numero].nombre + " el vehiculo " + vehiculo.tipo);
                                        vehiculo.stock = vehiculo.stock - 1;
                                        break;
                                    }

                                }
                            }
                            if (elecion == 4)
                            {
                                foreach (Vehiculo vehiculo in sucursalita.vehiculos)
                                {
                                    if (vehiculo.stock > 0 && vehiculo.tipo == "bus")
                                    {
                                        int numero = random.Next(1, 150);
                                        libreta.Add("se arrendo al cliente " + clientess[numero].nombre + " el vehiculo " + vehiculo.tipo);
                                        vehiculo.stock = vehiculo.stock - 1;
                                        break;
                                    }

                                }
                            }
                            if (elecion == 5)
                            {
                                foreach (Vehiculo vehiculo in sucursalita.vehiculos)
                                {
                                    if (vehiculo.stock > 0 && vehiculo.tipo == "retro excabadora")
                                    {
                                        int numero = random.Next(1, 150);
                                        libreta.Add("se arrendo al cliente " + clientess[numero].nombre + " el vehiculo " + vehiculo.tipo);
                                        vehiculo.stock = vehiculo.stock - 1;
                                        break;
                                    }

                                }
                            }
                            if (elecion == 5)
                            {
                                foreach (Vehiculo vehiculo in sucursalita.vehiculos)
                                {
                                    if (vehiculo.stock > 0 && vehiculo.tipo == "moto")
                                    {
                                        int numero = random.Next(1, 150);
                                        libreta.Add("se arrendo al cliente " + clientess[numero].nombre + " el vehiculo " + vehiculo.tipo);
                                        vehiculo.stock = vehiculo.stock - 1;
                                        break;
                                    }

                                }
                            }

                        }
                    foreach ( string str in libreta)
                        {
                            Console.WriteLine(str);
                        }
                    foreach (Vehiculo vehiculo in sucursalita.vehiculos)
                        {
                            Console.WriteLine(vehiculo.stock);
                        }
                    }
                }
                if (opcion == "4")
                {
                    carRental.mostrarsucursales();
                }
                if (opcion == "5")
                {
                    Console.WriteLine("ingrese nombre de la sucursal donde quiere ver sus vehiculos y stock");
                    string y = Console.ReadLine();
                    carRental.mostrarvehiculos(y);
                }
                if (opcion == "6")
                {
                    Console.WriteLine("vuelva pronto");
                    break;

                }
                if (opcion == "7")
                {
                    carRental.Confirmation2("ingrese nombre del cliente a que quiere arrendar");
                    string nombrec = Console.ReadLine();
                    if (carRental.reconocerCliente(nombrec))
                    {
                        carRental.agregarCliente(nombrec);
                    }
                    carRental.Confirmation2("ingrese tipo de vehiculo a arrendar");
                        string tipoo = Console.ReadLine();
                        carRental.crearArriendo(tipoo, nombrec);
                    
                }
                if (opcion != "1" && opcion != "2" && opcion != "3" && opcion != "4" && opcion != "5" && opcion != "6" && opcion != "7" && opcion != "8")
                {
                    string msg = "opcion ingresada no valida";
                    carRental.Warning(msg);
                    Console.Beep();
                    Console.Beep();
                }
                if (opcion == "8")
                {
                    carRental.Confirmation2("ingrese tipo de vehiculo a entregar ");
                    string he =  Console.ReadLine();
                    carRental.entregarvehiculo(he);
                }

                }
            Console.ReadKey();
        }
    }
}
