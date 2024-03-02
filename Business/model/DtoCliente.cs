using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.model
{
    public class DtoCliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public ICollection<DtoEndereco>? Enderecos { get; set; }
    }
}
