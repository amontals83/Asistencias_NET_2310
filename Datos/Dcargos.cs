using Asistencias.Logica;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asistencias.Datos
{
    public class Dcargos
    {
        public bool InsertarCargo(Lcargos param)
        {
            try
            {
                ConexionDB.AbrirConexion();
                //SqlCommand para alterar la base de datos (insertar, editar o eliminar) para mostrar es SqlDataAdapter
                SqlCommand cmd = new SqlCommand("InsertarCargo", ConexionDB.Conectar);
                //Indicamos que el tipo de parametro es de procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cargo", param.Cargo);
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

        public bool EditarCargo(Lcargos param)
        {
            try
            {
                ConexionDB.AbrirConexion();
                //SqlCommand para alterar la base de datos (insertar, editar o eliminar) para mostrar es SqlDataAdapter
                SqlCommand cmd = new SqlCommand("EditarCargo", ConexionDB.Conectar);
                //Indicamos que el tipo de parametro es de procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", param.Id_cargo);
                cmd.Parameters.AddWithValue("@Cargo", param.Cargo);
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

        public void BuscarCargo(ref DataTable dt, String buscador) //Hacemos referencia donde vamos a mostrar los datos
        {
            try
            {
                ConexionDB.AbrirConexion();
                //SqlDataAdapter para mostrar datos de la base de datos.
                SqlDataAdapter da = new SqlDataAdapter("BuscarCargo", ConexionDB.Conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure; //'SelectCommand' es para mandar un comando
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
