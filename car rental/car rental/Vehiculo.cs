using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental
{
    public class Vehiculo
    {
        public string tipo;
        public int stock;
        public Vehiculo(string tipo1,int stock1)
        {
            tipo = tipo1;
            stock = stock1;
        }
    }
}
