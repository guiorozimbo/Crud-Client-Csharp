using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObejtoTransferencia
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string nome { get; set; }
        public DateTime DataNascimento { get; set; }
       public Boolean Sexo { get; set; }
        public decimal LimiteCompra { get; set; }

    }
}
