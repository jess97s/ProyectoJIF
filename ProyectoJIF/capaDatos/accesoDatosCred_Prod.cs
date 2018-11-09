using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using capaEntidades;
using System.Data;

namespace capaDatos
{
    public class accesoDatosCred_Prod
    {
        SqlConnection cnx;
        Cred_Prod crp = new Cred_Prod();
        Conexion cn = new Conexion();
        SqlCommand cm = null;
        int indicador = 0;
        SqlDataReader dr = null;
        List<Cred_Prod> listaCred_Prod = null;

        public int insertarCred_Prod(Cred_Prod cp)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("nuevoCred_Prod", cnx);
                cm.Parameters.AddWithValue("@b", 1);
                cm.Parameters.AddWithValue("@id_cp", "");
                cm.Parameters.AddWithValue("@id_producto", cp.id_producto);
                cm.Parameters.AddWithValue("@id_credito", cp.id_credito);
                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cm.ExecuteNonQuery();
                indicador = 1;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }
            finally { cm.Connection.Close(); }
            return indicador;
        }

        public List<Cred_Prod> ListarCred_Prod()
        {
            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("nuevoCred_Prod", cnx);
                cm.Parameters.AddWithValue("@b", 2);
                cm.Parameters.AddWithValue("@id_cp", "");
                cm.Parameters.AddWithValue("@id_producto", "");
                cm.Parameters.AddWithValue("@id_credito", "");
                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaCred_Prod = new List<Cred_Prod>();
                while (dr.Read())
                {
                    Cred_Prod crpr = new Cred_Prod();
                    crpr.id_cp = Convert.ToInt32(dr["id_cp"].ToString());
                    crpr.id_credito = Convert.ToInt32(dr["id_credito"].ToString());
                    crpr.id_producto = Convert.ToInt32(dr["id_producto"].ToString());
                    listaCred_Prod.Add(crpr);
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
                listaCred_Prod = null;
            }
            finally
            {
                cm.Connection.Close();
            }
            return listaCred_Prod;
        }

        public int EditarCred_Prod(Cred_Prod cp)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("nuevoCred_Prod", cnx);
                cm.Parameters.AddWithValue("@b", 3);
                cm.Parameters.AddWithValue("@id_cp", cp.id_cp);
                cm.Parameters.AddWithValue("@id_credito", cp.id_credito);
                cm.Parameters.AddWithValue("@id_producto", cp.id_producto);

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cm.ExecuteNonQuery();
                indicador = 1;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }
            finally { cm.Connection.Close(); }
            return indicador;
        }

        public int EliminarCred_prod(int id_cp)
        {
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("nuevoCred_prod", cnx);
                cm.Parameters.AddWithValue("@b", 4);
                cm.Parameters.AddWithValue("@idCliente", id_cp);
                cm.Parameters.AddWithValue("@nid_credito", "");
                cm.Parameters.AddWithValue("@aid_producto", "");
                

                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                cm.ExecuteNonQuery();
                indicador = 1;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                indicador = 0;
            }
            finally
            { cm.Connection.Close(); }
            return indicador;
        }

        public Cred_Prod BuscarCred_prodXcodigo(int id_cp)
        {
            Cred_Prod cp = new Cred_Prod();
            try
            {
                SqlConnection cnx = cn.conectar();

                cm = new SqlCommand("nuevoCred_prod", cnx);
                cm.Parameters.AddWithValue("@b", 5);
                cm.Parameters.AddWithValue("@id_cp", id_cp);
                cm.Parameters.AddWithValue("@id_credito", "");
                cm.Parameters.AddWithValue("@id_producto", "");
                
                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                dr.Read();

                cp.id_cp = Convert.ToInt32(dr["idc_cp"].ToString());
                cp.id_credito = Convert.ToInt32(dr["id_credito"].ToString());
                cp.id_producto = Convert.ToInt32(dr["id_producto"].ToString());
                

            }
            catch (Exception e)
            {
                e.Message.ToString();
                cp = null;
            }
            finally
            {
                cm.Connection.Close();

            }
            return cp;
        }
        public List<Cred_Prod> BuscaCred_prodDatos(String dato)
        {

            try
            {
                SqlConnection cnx = cn.conectar();
                cm = new SqlCommand("nuevoCred_prod", cnx);
                cm.Parameters.AddWithValue("@b", 6);
                cm.Parameters.AddWithValue("@id_cp", "");
                cm.Parameters.AddWithValue("@id_credito", dato);
                cm.Parameters.AddWithValue("@id_producto", "");
               
                cm.CommandType = CommandType.StoredProcedure;
                cnx.Open();
                dr = cm.ExecuteReader();
                listaCred_Prod = new List<Cred_Prod>();
                while (dr.Read())
                {
                    Cred_Prod cp = new Cred_Prod();
                    cp.id_cp = Convert.ToInt32(dr["idcp"].ToString());
                    cp.id_credito = Convert.ToInt32(dr["id_credito"].ToString());
                    cp.id_producto = Convert.ToInt32(dr["id_producto"].ToString());
                    
                    listaCred_Prod.Add(cp);
                }

            }
            catch (Exception e)
            {
                e.Message.ToString();
                listaCred_Prod = null;
            }
            finally { cm.Connection.Close(); }
            return listaCred_Prod;
        }

    }
}
