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
        public void agregar_sucursal()
        {
            Console.WriteLine("ingrese nombre sucursal nueva");
            string nombre = Console.ReadLine();

            List<Vehiculo> vehiculos = new List<Vehiculo>();
            while (true)
            {
                Console.WriteLine("ingrese vehiculos por tipo y escriba listo para detenerse");
                string opcion = Console.ReadLine();
                if (opcion == "listo")
                {
                    Console.WriteLine("añadiendo vehiculos");
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
                Console.WriteLine("ingrese accesorios nombre y escriba listo para detenerse");
                string opcion = Console.ReadLine();
                if (opcion == "listo")
                {
                    Console.WriteLine("añadiendo accesorios");
                    break;
                }
                else
                {
                    Console.WriteLine("ingrese stock ,maximo 32 int");
                    int stock = Convert.ToInt32(Console.ReadLine());
                    Accesorio accesorio = new Accesorio(opcion, stock);
                    accesorios.Add(accesorio);
                }


            }
            Sucursal suc = new Sucursal(vehiculos, nombre, accesorios);
            this.sucursales.Add(suc);
            Console.WriteLine("sucursal añadida");


        }
            public void agregarCliente(string nombre)
             {
            Console.WriteLine("insertar tipo de cliente, ej;\n persona\n organizacion \n institucion");
            string tipo = Console.ReadLine();
            if (tipo ==  "persona")
            {
                Console.WriteLine("persona creada con licencia para poder ingresar a la base de datos");
                Persona persona = new Persona(true,tipo,nombre);
                this.clientes.Add(persona);
            }
            if (tipo == "organizacion" || tipo == "institucion")
            {
                Console.WriteLine("cada empresa viene con su autorizacion para arrendar para poder ingresar a la base de datos");
                OrganizacionInstitucion org = new OrganizacionInstitucion(true,tipo,nombre);
                this.clientes.Add(org);
            }
            
            
             }
        

        public void crearArriendo(string tipo, string nombre)
        {
            foreach (Sucursal sucursal in this.sucursales)
            {
                
                foreach (Vehiculo vehiculo in sucursal.vehiculos)
                {
                    if (tipo == vehiculo.tipo)
                    {
                        vehiculo.stock = vehiculo.stock - 1;
                        while (true)
                        {
                            List<Accesorio> accesoriosarriendo = new List<Accesorio>();
                            Console.WriteLine("agregar a continuacion accesorios para el auto \n en el caso de no querer accesorios, escribir listo");
                            string nombreAccesorio = Console.ReadLine();
                            if (nombreAccesorio == "listo")
                            {
                                foreach (Cliente cliente in this.clientes)
                                {
                                    if (nombre == cliente.nombre)
                                    {
                                        Arrendar arriendo = new Arrendar(accesoriosarriendo, cliente, sucursal, vehiculo);
                                        this.arriendos.Add(arriendo);
                                        
                                    }
                                }
                            }
                            foreach (Accesorio ace in sucursal.accesorios)
                            {
                                if (nombreAccesorio == ace.nombre && ace.stock >= 1)
                                {
                                    ace.stock = ace.stock - 1;
                                    accesoriosarriendo.Add(ace);
                                }
                            }
                        }

                    }
                    
                }
            }
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
        }
    
}
