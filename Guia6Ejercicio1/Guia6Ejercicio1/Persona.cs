using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Guia6Ejercicio1
{
    class Persona
    {
        //CAMPOS
        //(protected: indica que seran visibles solo en interior de
        //los miembros de esta clase base y sus clases derivadas)
        protected string nombre;
        protected string foto; //URL de foto seleccionada para empleado
        protected DateTime fechanac;
        protected float sueldo;
        //METODOS
        public Persona() //constructor
        {
            nombre = "";
            foto = ""; //url de foto-empleado aun no asignada
            fechanac = Convert.ToDateTime("1900/01/01"); //fecha predeterminada
        }
        public virtual void asignarfechanac(string anno, string mes, string dia)
        {
            /*
            Este metodo debera ser reemplazado en clases derivadas, con otro metodo
            que tenga el mismo encabezado (lista de parametros o firma)
            */
            fechanac = Convert.ToDateTime(anno + "/" + mes + "/" + dia);
            MessageBox.Show("de clase Persona");
        }
        //PROPIEDAD
        public string nombreempleado
        {
            //accede a propiedad: nombre
            get
            {
                return (nombre);
            }
            set
            {
                if (value.Length > 1)
                    nombre = value;
                else
                    nombre = "";
            }
        }
        public string URLfoto
        { //accede a la URL del archivo JPG elegido por la persona
            get
            {
                return (foto); //retorna la URL de donde se selecciono foto
            }
            set
            { //recibe la url de la imagen seleccionada por usuario
                if (nombre == "")
                {
                    MessageBox.Show("usuario no tiene aun nombre asignado");
                }
                else
                {
                    //genera la URL del nuevo archivo JPG, que se copiara hacia carpeta de esta aplicacion
                    foto = Application.StartupPath + "\\" + nombre + ".jpg";
                    //Copia archivo de ubic. elegida por usuario hacia ruta del ejecutable del proyecto actual
                    File.Copy(value, foto, true);
                }
            }
        }
        public float sueldobase
        {
            //acceso lectura-escritura hacia campo sueldo
            get
            {
                return (sueldo);
            }
            set
            {
                if (value > 0)
                    sueldo = value;
                else
                    MessageBox.Show("Valor de sueldo incorrecto", "ERROR-SISTEMA", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        public string fecha_nacimiento
        { //propiedad solo-lectura
            get
            {
                return (fechanac.ToShortDateString().ToString());
            }
        }
    }
}
