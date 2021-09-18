using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data;
using System.Data.SqlClient;

namespace Repositorios
{
    public class RepoClientes : IRepositorio<Cliente>
    {
        public bool Alta(Cliente obj)
        {
            bool ret = false;

            string strCon = @"Data Source=ACER-GON\SQLEXPRESS; Initial Catalog=BaseDistribuidora; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);
            
            string sql = "insert into Clientes(Nombre, Apellido, RazonSocial, Telefono) values(@nom, @ape, @razon, @tel);";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("@nom", obj.Nombre);
            com.Parameters.AddWithValue("@ape", obj.Apellido);
            com.Parameters.AddWithValue("@razon", obj.RazonSocial);
            com.Parameters.AddWithValue("@tel", obj.Telefono);

            try
            {
                con.Open();
                int afectadas = com.ExecuteNonQuery();
                con.Close();

                ret = afectadas == 1;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }

            return ret;
        }

        public bool Baja(int id)
        {
            bool ret = false;

            string strCon = @"Data Source=ACER-GON\SQLEXPRESS; Initial Catalog=BaseDistribuidora; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "delete from Clientes where id=@id;";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("@id", id);            

            try
            {
                con.Open();
                int afectadas = com.ExecuteNonQuery();
                con.Close();

                ret = afectadas == 1;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }

            return ret;
        }        

        public bool Modificacion(Cliente obj)
        {
            bool ret = false;

            string strCon = @"Data Source=ACER-GON\SQLEXPRESS; Initial Catalog=BaseDistribuidora; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "update Clientes set Nombre=@nom, Apellido=@ape, RazonSocial=@razon, Telefono=@tel where Id=@id;";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("@nom", obj.Nombre);
            com.Parameters.AddWithValue("@ape", obj.Apellido);
            com.Parameters.AddWithValue("@razon", obj.RazonSocial);
            com.Parameters.AddWithValue("@tel", obj.Telefono);
            com.Parameters.AddWithValue("@id", obj.Id);

            try
            {
                con.Open();
                int afectadas = com.ExecuteNonQuery();
                con.Close();

                ret = afectadas == 1;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }

            return ret;
        }

        public List<Cliente> TraerTodo()
        {
            List<Cliente> clientes = new List<Cliente>();

            string strCon = @"Data Source=ACER-GON\SQLEXPRESS; Initial Catalog=BaseDistribuidora; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Clientes";
            SqlCommand com = new SqlCommand(sql, con);            

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cli = new Cliente
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Apellido = reader.GetString(2),
                        RazonSocial = reader.GetString(3),
                        Telefono = reader.GetString(4)
                    };

                    clientes.Add(cli);
                }

                con.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }

            return clientes;
        }

        public Cliente BuscarPorId(int id)
        {
            Cliente cli = null;

            string strCon = @"Data Source=ACER-GON\SQLEXPRESS; Initial Catalog=BaseDistribuidora; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "select * from Clientes where Id=@id;";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    cli = new Cliente
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Apellido = reader.GetString(2),
                        RazonSocial = reader.GetString(3),
                        Telefono = reader.GetString(4)
                    };
                }

                con.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }

            return cli;

        }
    }
}
