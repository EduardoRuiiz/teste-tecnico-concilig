using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportadorContratos.App.Models
{
    public class Contrato
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string NumeroContrato { get; set; }
        public string Produto { get; set; }
        public DateTime Vencimento { get; set; }
        public decimal Valor { get; set; }
    }
}

