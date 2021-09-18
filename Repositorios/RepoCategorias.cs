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
    class RepoCategorias : IRepositorio<Categoria>
    {
        public bool Alta(Categoria obj)
        {
            bool ret = false;

            string strCon = @"Data Source=ACER-GON\SQLEXPRESS; Initial Catalog=BaseDistribuidora; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            string sql = "insert into Categorias(Nombre, Descripcion) values(@nom, @desc);";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("@nom", obj.Nombre);
            com.Parameters.AddWithValue("@desc", obj.Descripcion);

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
            return false;
        }

        public bool Modificacion(Categoria obj)
        {
            return false;
        }

        public List<Categoria> TraerTodo()
        {
            List<Categoria> ret = new List<Categoria>();
            return ret;
        }

        public Categoria BuscarPorId(int id)
        {
            Categoria ret = new Categoria();
            return ret;
        }
    }
}
