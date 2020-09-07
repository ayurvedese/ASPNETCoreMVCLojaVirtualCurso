using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Models
{
    public class Produto
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public string nome { get; set; }
        public decimal valor { get; set; }

    }
}
