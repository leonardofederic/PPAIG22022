using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAi.Entidades;

namespace PPAi.Formularios
{
    public class Class1
    {




        public static DataTable mostrarMontosVigentes(int id_usu)
        {
            String cadenaConexion = "Data Source=.\\SQLEXPRESS;Initial Catalog=PPAi;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand comando = new SqlCommand();
                String consulta = "select t.idTarifa, t.fechaFinVigencia, t.monto, te.nombre, tv.nombre from Tarifa t, TipoDeEntrada te, TipoVisita tv where t.idTipoEntrada = te.idTipoEntrada AND t.idTipoVisita = tv.idTipoVisita AND t.fechaFinVigencia > getdate()";
                comando.Parameters.AddWithValue("@idSede", id_usu.ToString());
                comando.CommandType = CommandType.Text;
                comando.CommandText = consulta;
                cn.Open();
                comando.Connection = cn;
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable tabla = new DataTable();
                da.Fill(tabla);
                return tabla;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }
            public static int cargarGrilla(int id_usu)
            {
                String cadenaConexion = "Data Source=.\\SQLEXPRESS;Initial Catalog=PPAi;Integrated Security=True";
                SqlConnection cn = new SqlConnection(cadenaConexion);
                try
                {
                    SqlCommand comando = new SqlCommand();
                    String consulta = "select t.idTarifa, t.fechaFinVigencia, t.monto, te.nombre, tv.nombre from Tarifa t, TipoDeEntrada te, TipoVisita tv where t.idTipoEntrada = te.idTipoEntrada AND t.idTipoVisita = tv.idTipoVisita AND t.fechaFinVigencia > getdate()";
                    comando.Parameters.AddWithValue("@idSede", id_usu.ToString());
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = consulta;
                    cn.Open();
                    comando.Connection = cn;
                    SqlDataAdapter da = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);
                    return id_usu;

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    cn.Close();
                }

            }



        
    }
}
