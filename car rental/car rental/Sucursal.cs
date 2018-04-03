using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental
{
    public class Sucursal
    {
        public List<Vehiculo> vehiculos = new List<Vehiculo>();
        public string nombre;
        public List<Accesorio> accesorios = new List<Accesorio>();

        public Sucursal(List<Vehiculo> vehiculos1, string nombre1, List<Accesorio> accesorios1)
        {
            vehiculos = vehiculos1;
            nombre = nombre1;
            accesorios = accesorios1;
        }
        public void agregar_vehiculos(Vehiculo vehiculo)
        {
       
            this.vehiculos.Add(vehiculo);
        }
    }
}
