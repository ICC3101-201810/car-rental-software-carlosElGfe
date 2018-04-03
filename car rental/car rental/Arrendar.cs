using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental
{
    public class Arrendar
    {
        public List<Accesorio> accesorios = new List<Accesorio>();
        public Cliente cliente;
        public Sucursal sucursal;
        public Vehiculo vehiculo;
        public Arrendar(List<Accesorio> accesorios1, Cliente cliente1, Sucursal sucursal1, Vehiculo vehiculo1)
        {
            accesorios = accesorios1;
            cliente = cliente1;
            sucursal = sucursal1;
            vehiculo = vehiculo1;
        }
        
    }
}
