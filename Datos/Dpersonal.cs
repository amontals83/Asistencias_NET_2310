using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Asistencias.Logica;
using System.Windows.Forms;

namespace Asistencias.Datos
{
    public class Dpersonal
    {
        public bool InsertarPersonal(Lpersonal param)
        {
			try
			{
                ConexionDB.AbrirConexion();
                //SqlCommand para alterar la base de datos (insertar, editar o eliminar) para mostrar es SqlDataAdapter
                SqlCommand cmd = new SqlCommand("InsertarPersonal", ConexionDB.Conectar);
                //Indicamos que el tipo de parametro es de procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", param.Nombre);
                cmd.Parameters.AddWithValue("@DNI", param.DNI);
                cmd.Parameters.AddWithValue("@Pais", param.Pais);
                cmd.Parameters.AddWithValue("@Id_cargo", param.Id_cargo);
                cmd.Parameters.AddWithValue("@SueldoPorHora", param.SueldoPorHora);
                cmd.ExecuteNonQuery();
                return true;
            }
			catch (Exception ex)
			{
                //Utilizamos '.Message' y no 'StackTrace' ya que en las procedures tenemos un 'RAISERROR' 
                MessageBox.Show(ex.Message);
                return false;
			}
            finally
            {
                ConexionDB.CerrarConexion();
            }
           
        }

        public bool EditarPersonal(Lpersonal param)
        {
            try
            {
                ConexionDB.AbrirConexion();
                //SqlCommand para alterar la base de datos (insertar, editar o eliminar) para mostrar es SqlDataAdapter
                SqlCommand cmd = new SqlCommand("EditarPersonal", ConexionDB.Conectar);
                //Indicamos que el tipo de parametro es de procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_personal", param.Id_personal);
                cmd.Parameters.AddWithValue("@Nombre", param.Nombre);
                cmd.Parameters.AddWithValue("@DNI", param.DNI);
                cmd.Parameters.AddWithValue("@Pais", param.Pais);
                cmd.Parameters.AddWithValue("@Id_cargo", param.Id_cargo);
                cmd.Parameters.AddWithValue("@SueldoPorHora", param.SueldoPorHora);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                //Utilizamos '.Message' y no 'StackTrace' ya que en las procedures tenemos un 'RAISERROR' 
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionDB.CerrarConexion();
            }

        }

        public bool EliminarPersonal(Lpersonal param)
        {
            try
            {
                ConexionDB.AbrirConexion();
                //SqlCommand para alterar la base de datos (insertar, editar o eliminar) para mostrar es SqlDataAdapter
                SqlCommand cmd = new SqlCommand("EliminarPersonal", ConexionDB.Conectar);
                //Indicamos que el tipo de parametro es de procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_personal", param.Id_personal);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                //Utilizamos '.Message' y no 'StackTrace' ya que en las procedures tenemos un 'RAISERROR' 
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionDB.CerrarConexion();
            }

        }

        public void MostrarPersonal(ref DataTable dt, int desde, int hasta) //Hacemos referencia donde vamos a mostrar los datos
        {
            try
            {
                ConexionDB.AbrirConexion();
                //SqlDataAdapter para mostrar datos de la base de datos.
                SqlDataAdapter da = new SqlDataAdapter("MostrarPersonal", ConexionDB.Conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure; //'SelectCommand' es para mandar un comando
                da.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                da.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                ConexionDB.CerrarConexion();
            }
        }

        public void BuscarPersonal(ref DataTable dt, int desde, int hasta, String buscador) //Hacemos referencia donde vamos a mostrar los datos
        {
            try
            {
                ConexionDB.AbrirConexion();
                //SqlDataAdapter para mostrar datos de la base de datos.
                SqlDataAdapter da = new SqlDataAdapter("BuscarPersonal", ConexionDB.Conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure; //'SelectCommand' es para mandar un comando
                da.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                da.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                da.SelectCommand.Parameters.AddWithValue("@Buscador", buscador);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                ConexionDB.CerrarConexion();
            }
        }
    }
}


