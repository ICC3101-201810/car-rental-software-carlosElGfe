using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental
{
    public class OrganizacionInstitucion : Cliente
    {
        public bool autorizacion;
        public OrganizacionInstitucion(bool autorizacion1, string tipo, string nombre) : base(tipo, nombre)
        {
            autorizacion = autorizacion1;

        }
        public Arrendar arrendar(Sucursal sucursal, Vehiculo vehiculo, List<Accesorio> accesorios)
        {
            if (this.autorizacion)
            {
                Arrendar arrendar1 = new Arrendar(accesorios, this, sucursal, vehiculo);
                return arrendar1;
            }
            else
            {
                Arrendar arriendofalso = new Arrendar(accesorios, this, sucursal, vehiculo);
                return arriendofalso;
            }

        }
    }
}
