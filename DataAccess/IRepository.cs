using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepository
    {
        public void Salvar(Cliente cliente);
        public Cliente RetornarLista(string cpf);
        public void Alterar(Endereco endereco);
        public void Deletar(int id);
    }
}
