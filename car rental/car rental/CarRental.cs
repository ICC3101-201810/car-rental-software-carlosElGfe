using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental
{
    public class CarRental
    {
        public List<Arrendar> arriendos = new List<Arrendar>();
        public List<Sucursal> sucursales = new List<Sucursal>();
        public List<Cliente> clientes = new List<Cliente>();
        public CarRental(List<Arrendar> arriendos1, List<Sucursal>sucursales1,List<Cliente> clientes1)
        {
            arriendos = arriendos1;
            sucursales = sucursales1;
            clientes = clientes1;

        }
        public void Confirmation(string message)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public void Confirmation2(string message)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public void Warning(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public void agregar_sucursal()
        {
            this.Confirmation2("ingrese nombre sucursal nueva");
            string nombre = Console.ReadLine();

            List<Vehiculo> vehiculos = new List<Vehiculo>();
            while (true)
            {
                this.Confirmation2("ingrese vehiculos por tipo, uno por uno, y escriba listo para detenerse \n ej:  auto   5");
                string opcion = Console.ReadLine();
                if (opcion == "listo")
                {
                    this.Confirmation("añadiendo vehiculos");
                    break;
                }
                else
                {
                    Console.WriteLine("ingrese stock ,maximo 32 int");
                    int stock = Convert.ToInt32(Console.ReadLine());
                    Vehiculo vehiculo = new Vehiculo(opcion, stock);
                    vehiculos.Add(vehiculo);
                }

               
            }
            List<Accesorio> accesorios  = new List<Accesorio>();
            while (true)
            {
                this.Confirmation2("ingrese accesorios nombre y escriba listo para detenerse");
                string opcion = Console.ReadLine();
                if (opcion == "listo")
                {
                    this.Confirmation("añadiendo accesorios");
                    break;
                }
                else
                {
                    this.Confirmation2("ingrese stock ,maximo 32 int");
                    int stock = Convert.ToInt32(Console.ReadLine());
                    Accesorio accesorio = new Accesorio(opcion, stock);
                    accesorios.Add(accesorio);
                }


            }
            Sucursal suc = new Sucursal(vehiculos, nombre, accesorios);
            this.sucursales.Add(suc);
            this.Confirmation("sucursal añadida");
            Console.Beep();


        }
            public void agregarCliente(string nombre)
             {
            this.Confirmation2("insertar tipo de cliente, ej;\n persona\n organizacion \n institucion");
            string tipo = Console.ReadLine();
            if (tipo ==  "persona")
            {
                this.Confirmation("persona creada con licencia para poder ingresar a la base de datos");
                Persona persona = new Persona(true,tipo,nombre);
                this.clientes.Add(persona);
                Console.Beep();
            }
            if (tipo == "organizacion" || tipo == "institucion")
            {
                this.Confirmation("cada empresa viene con su autorizacion para arrendar para poder ingresar a la base de datos");
                OrganizacionInstitucion org = new OrganizacionInstitucion(true,tipo,nombre);
                this.clientes.Add(org);
                Console.Beep();
            }
            
            
             }

        public void mostrarsucursales()
        {
            foreach (Sucursal s in this.sucursales)
            {
                Console.WriteLine(s.nombre);
                Console.Beep();
            }
        }
        public void mostrarvehiculos(string nombre)
        {
            foreach (Sucursal item in this.sucursales)
            {
                foreach (Vehiculo vehiculo in item.vehiculos)
                {
                    Console.WriteLine(vehiculo.tipo + vehiculo.stock) ;
                    Console.Beep();
                }
            }
        }
        public Arrendar crearArriendo(string tipo, string nombre)
        {
            List<Accesorio> accesoriosarriendo = new List<Accesorio>();
            foreach (Sucursal sucursal in this.sucursales)
            {
                
                foreach (Vehiculo vehiculo in sucursal.vehiculos)
                {
                    if (tipo == vehiculo.tipo && vehiculo.stock >= 1)
                    {
                        
                        vehiculo.stock = vehiculo.stock - 1;
                        this.Confirmation("se encontro un vehiculo de ese tipo");
                        if (tipo == "auto")
                        {
                            this.Confirmation2("¿desea corrida de asientos extra? si/no");
                            string corrida = Console.ReadLine();
                            this.Confirmation2("¿desea maletero XL? si/no");
                            string maleta = Console.ReadLine();
                        }

                        while (true)
                        {
                            
                            this.Confirmation2("agregar a continuacion accesorios para el auto \n en el caso de no querer accesorios, escribir listo");
                            string nombreAccesorio = Console.ReadLine();
                            if (nombreAccesorio == "listo")
                            {
                                
                                foreach (Cliente cliente in this.clientes)
                                {
                                    if (nombre == cliente.nombre)
                                    {
                                        Arrendar arriendo = new Arrendar(accesoriosarriendo, cliente, sucursal, vehiculo);
                                        this.arriendos.Add(arriendo);
                                        this.Confirmation("arriendo creado");
                                        Console.Beep();
                                        return arriendo;
                                        break;

                                    }
                                }
                                break;
                            }
                            Console.WriteLine("comparando con accesorios");
                            foreach (Accesorio ace in sucursal.accesorios)
                            {
                                if (nombreAccesorio == ace.nombre && ace.stock >= 1)
                                {
                                    ace.stock = ace.stock - 1;
                                    accesoriosarriendo.Add(ace);
                                    this.Confirmation("accesorio adjuntado!");
                                    Console.Beep();
                                }
                            }
                        }
                        foreach (Cliente item in this.clientes)
                        {
                            foreach (Vehiculo vehiculo2 in sucursal.vehiculos)
                            {
                                if (tipo == vehiculo2.tipo)
                                {
                                    if (item.nombre == nombre)
                                    {
                                        Arrendar arriendonuevo = new Arrendar(accesoriosarriendo, item, sucursal,vehiculo2);
                                        this.arriendos.Add(arriendonuevo);
                                        this.Confirmation("Arriendo creado y guardado!");
                                        return arriendonuevo;
                                    }
                                }
                            }
                            
                        }
                        

                    }
                    
                }

            }
            
            Vehiculo h = new Vehiculo("h", 4);
            List<Accesorio> ac = new List<Accesorio>();
            List<Vehiculo> v = new List<Vehiculo>();
            Sucursal s = new Sucursal(v, "", ac);
            Cliente c = new Cliente("persona", "hugo");
            Arrendar a = new Arrendar(accesoriosarriendo, c, s, h);
            Console.Beep();
            Console.Beep();
            return a;
        }
        public bool reconocerCliente(string nombre)
        {
            foreach (Cliente cliente in clientes)
            {
                if (cliente.nombre == nombre)
                {
                    return false;
                }
            }
            return true;
        }
        public bool reconocerVehiculoEyE(string tipo)
        {
            foreach (Sucursal sucursal in sucursales)
            {
                foreach (Vehiculo vehiculo in sucursal.vehiculos)
                {
                    if (tipo == vehiculo.tipo && vehiculo.stock>=1)
                    {
                        return true;
                    }
                }
            }
            return false;
            
        }
        public void entregarvehiculo(string tipo) {
            foreach (Arrendar arriendo in this.arriendos)
            {
                if (tipo ==  arriendo.vehiculo.tipo)
                {
                    foreach (Sucursal s in this.sucursales)
                    {
                        foreach (Vehiculo item in s.vehiculos)
                        {
                            if (item.tipo == tipo)
                            {
                                this.Confirmation("devolviendo auto de forma exitosa...");
                                item.stock = item.stock - 1;
                                Console.Beep();
                                return;
                                break;
                            }
                        }
                    }
                    
                }
            }
            this.Warning("no se encontro ningun vehiculo, no es necesario devolver");
            Console.Beep();
            Console.Beep();
        }

        }
    
}
