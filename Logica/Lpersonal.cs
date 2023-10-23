using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencias.Logica
{
    public class Lpersonal
    {
        public int Id_personal {  get; set; }
        public String Nombre { get; set; }
        public String DNI { get; set; }
        public String Pais { get; set; }
        public int Id_cargo { get; set; }
        public double SueldoPorHora { get; set; }
        public String Estado { get; set; }
        public String Codigo { get; set; }
    }
}
