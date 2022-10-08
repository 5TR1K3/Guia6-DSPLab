using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Guia6Ejercicio1
{
    class ClsDoctor: Persona
    {
        //campo privado: solo accesibles en interior de esta clase
        string cod_doctor;
        //Propiedades
        public string codigodoctor
        {
            get
            {
                return (cod_doctor);
            }
            set
            {
                cod_doctor = value;
            }
        }
        //Metodos
        public ClsDoctor()
        {//metodo constructor
            nombre = "";
            sueldo = 5;
            fechanac = Convert.ToDateTime("1900/1/1");
        }
        //Este metodo en la clase Hija es el reemplazo exigido por la clase Base
        //->Observe que tiene el mismo nombre y FIRMA (lista/tipo de parametros) del metodo original
        public override void asignarfechanac(string anno, string mes, string dia)
        {
            TimeSpan diftiempo; //almacena un rango de tiempo entre 2 fechas
            try//detecta si la fecha no tiene el formato esperado
            {
                DateTime fnac = Convert.ToDateTime(anno + "/" + mes + "/" + dia);
                //calcula diferencia de tiempo entre fecha de nac. recibida y la fecha actual
                diftiempo = fnac - DateTime.Now;
                //determina si fecha ingresada es al menos 18 años antes de la fecha actual
                if (diftiempo.TotalDays < -365 * 18)
                    fechanac = fnac; //acepta fecha recibida en parametros
                else
                    MessageBox.Show("Fecha nacimiento debe ser al menos 18 años antes de hoy", "ERROR-Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException e)
            {
                MessageBox.Show("Fecha brindada es incorrecta", "ERROR-SISTEMA!!", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        //Sobrecarga de metodo:
        public void asignarfechanac(string fecha)
        {
            DateTime fechafin;
            //Funcion intenta convertir cadena fecha a tipo DateTime en fechafin.
            //Si es correcto, devuelve true
            if (DateTime.TryParse(fecha, out fechafin))
            {
                fechanac = fechafin;
            }
            else
                MessageBox.Show("Fecha de nacimiento es recibida", "ERROR DE SISTEMA!!", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        //Confirma si datos para agregar un Doctor son correctos
        public bool DatossonCorrectos()
        {
            if (nombre != "")
                if (sueldo > 0)
                    if (fechanac != Convert.ToDateTime("1900/01/01"))
                        return (true); //Los datos recibidos son correctos
                    else
                        MessageBox.Show("aun no se ha asignado fecha de nacimiento");
                else
                    MessageBox.Show("Sueldo incorrecto");
            else
                MessageBox.Show("Nombre aun no asignado");
            return (false);
        }
    }//fin clase clsDoctor
}
