using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Repositorios;

namespace Repositorios
{
    public static class FachadaDistribuidora
    {
        public static bool AltaCliente(string nombre, string apellido, string razonSocial, string telefono)
        {
            bool ret = false;
            Cliente cli = new Cliente()
            {
                Nombre = nombre,
                Apellido = apellido,
                RazonSocial = razonSocial,
                Telefono = telefono
            };
            RepoClientes repoCli = new RepoClientes();
            ret = repoCli.Alta(cli);
            return ret;

        }

        public static bool AltaCategoria(string nombre, string descripcion)
        {
            bool ret = false;
            Categoria cat = new Categoria()
            {
                Nombre = nombre,
                Descripcion = descripcion
            };
            RepoCategorias repoCat = new RepoCategorias();
            ret = repoCat.Alta(cat);
            return ret;

        }

        public static bool AltaProducto()
        {
            return true;
        }

        public static bool AltaProducto(string nombre, string descripcion, decimal precio, decimal tasaIva)
        {
            bool ret = false;
            Nacional prodNac = new Nacional()
            {
                Nombre = nombre,
                Descripcion = descripcion,
                Precio = precio,
                TasaIVA = tasaIva
            };
            RepoProductos repoProd = new RepoProductos();
            ret = repoProd.Alta(prodNac);
            return ret;

        }

        public static bool AltaProducto(string nombre, string descripcion, decimal precio, string paisOrigen)
        {
            bool ret = false;
            Importado prodImp = new Importado()
            {
                Nombre = nombre,
                Descripcion = descripcion,
                Precio = precio,
                NomPaisOrigen = paisOrigen
            };
            RepoProductos repoProd = new RepoProductos();
            ret = repoProd.Alta(prodImp);
            return ret;

        }
    }
}
