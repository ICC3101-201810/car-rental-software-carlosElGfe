using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental
{
    public class Cliente
    {
        public string tipo;
        public string nombre;
        public Cliente(string tipo1, string nombre1)
        {
            tipo = tipo1;
            nombre = nombre1;

        }
        public Arrendar arrendar(Sucursal sucursal, Vehiculo vehiculo, List<Accesorio> accesorios)
        {

            Arrendar arrendar1 = new Arrendar(accesorios, this, sucursal, vehiculo);
            return arrendar1;





        }
    }
}
