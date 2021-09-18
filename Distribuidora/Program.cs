using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorios;

namespace Distribuidora
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(FachadaDistribuidora.AltaCliente("Juan", "Perez", "JP S.A.", "12345678"));

            //Console.WriteLine(FachadaDistribuidora.AltaCategoria("Juguetes", "Juguetes para niños"));

            Console.WriteLine(FachadaDistribuidora.AltaProducto("Ballantines", "Whisky 18 años", 2300, "Belgica"));

            Console.WriteLine(FachadaDistribuidora.AltaProducto("Criadores", "Whisky lija", 550, 22));
        }
    }
}
