using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Observaciones { get; set; }
        public List<Item> Items { get; set; }
        public Cliente Cliente { get; set; }

    }
}
