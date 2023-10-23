using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Asistencias.Datos
{
    public class ConexionDB
    {
        public static String Conexion = @"Data source=DESKTOP-U6JK9OO\SQLEXPRESS; Initial Catalog=ASISTENCIAS; Integrated Security=true;";
        public static SqlConnection Conectar = new SqlConnection(Conexion);

        //Funcion para abrir la conexion si esta cerrada
        public static void AbrirConexion()
        {
            if (Conectar.State == ConnectionState.Closed)
            {
                Conectar.Open();                
            }
        }

        //Funcion para cerrar la conexion si esta abierta
        public static void CerrarConexion()
        {
            if (Conectar.State == ConnectionState.Open)
            {
                Conectar.Close();
            }
        }
    }
}
