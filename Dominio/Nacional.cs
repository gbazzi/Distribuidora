using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Nacional : Producto
    {
        public decimal TasaIVA { get; set; }

        public override string Tipo()
        {
            return "Nacional";
        }
    }
}
