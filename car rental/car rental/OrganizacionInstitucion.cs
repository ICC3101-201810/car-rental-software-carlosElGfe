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

    }
}
