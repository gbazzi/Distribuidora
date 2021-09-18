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
    public class RepoProductos : IRepositorio<Producto>
    {
        public bool Alta(Producto obj)
        {
            bool ret = false;

            string strCon = @"Data Source=ACER-GON\SQLEXPRESS; Initial Catalog=BaseDistribuidora; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(strCon);

            //Ver como implementar alta para productos Nacional o Importado
            if (obj.Tipo() == "Nacional")
            {
                
            } else
            {

            }

            string sql = "insert into Producto(Nombre, Descripcion, Precio, tasaIva) values(@nom, @desc, @precio, @tasaIva);";
            SqlCommand com = new SqlCommand(sql, con);

            com.Parameters.AddWithValue("@nom", obj.Nombre);
            com.Parameters.AddWithValue("@desc", obj.Descripcion);
            com.Parameters.AddWithValue("@precio", obj.Precio);


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
            throw new NotImplementedException();
        }

        public Producto BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Modificacion(Producto obj)
        {
            throw new NotImplementedException();
        }

        public List<Producto> TraerTodo()
        {
            throw new NotImplementedException();
        }
    }
}
