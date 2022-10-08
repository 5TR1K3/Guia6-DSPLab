using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Guia6Ejercicio1
{
    class ClsVendedor : Persona
    {
        //CAMPOS (propios de clase derivada)
        DateTime fechacontratac;

        //METODOS
        public ClsVendedor() //metodo constructor
        {
            fechanac = Convert.ToDateTime("1950/01/01");
            fechacontratac = Convert.ToDateTime("2000/01/01");
        }
        //Este metodo en la clase Hija reemplaza al metodo de la clase Base
        //->Observe que tiene el mismo nombre, pero diferente firma (lista de parametros)
        public new void asignarfechanac(DateTime fechanacimiento)
        {
            fechanac = fechanacimiento;
        }
        //PROPIEDADES
        public DateTime FechaContrato
        {
            get
            {
                return (fechacontratac);
            }
            set
            {
                this.fechacontratac = value;
            }
        }
    }//fin clase Vendedor
}
