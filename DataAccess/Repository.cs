using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Repository : IRepository
    {
        public Repository() { } 
        public Cliente Listar(string cpf)
        {
            return new Cliente();
        }
        public void Salvar(Cliente cliente) { 
        
            using(var conexao = new Contexto())
            {
              Cliente resposta =  conexao.Clientes.Where(X => X.CPF == cliente.CPF).FirstOrDefault();
               
                if (resposta == null)
                {
                    conexao.Clientes.Add(cliente);
                    
                }
                else
                {
                    int total = conexao.Enderecos.Where(X => X.ClienteId == resposta.Id).Select(x => x.ClienteId).FirstOrDefault();
                    var endreco = cliente.Enderecos.FirstOrDefault();
                    endreco.ClienteId = resposta.Id;
                    conexao.Enderecos.Add(endreco);
                    
                    
                    
                }
                conexao.SaveChanges();
            }
                
        }
        public Cliente RetornarLista(string cpf)
        {
            using(var conexao = new Contexto())
            {
                var clienteTabela = conexao.Clientes.Where(x=>x.CPF==cpf).FirstOrDefault();
                if (clienteTabela != null)
                {
                    var EnderecosTabela = conexao.Enderecos.Where(x => x.ClienteId == clienteTabela.Id).ToList();

                    var clienteRetorno = new Cliente()
                    {
                        Id= clienteTabela.Id,
                        CPF = clienteTabela.CPF,
                        Nome = clienteTabela.Nome,

                        Enderecos = new List<Endereco>()
                    };
                    foreach (var item in EnderecosTabela)
                    {

                        clienteRetorno.Enderecos.Add(item);

                    };

                    return clienteRetorno;
                }
                return new Cliente() {Nome="",CPF=cpf,Enderecos= new List<Endereco>() { new Endereco() { Rua = "cadastrar endereço",Bairro="",Cidade="",Estado="",Id=0,ClienteId=0} } };
            }


        }
        public void Alterar(Endereco endereco)
        {
            using(var conexao = new Contexto())
            {
                var clienteEndereco = conexao.Enderecos.Where(x=>x.Id==endereco.Id).FirstOrDefault();
                clienteEndereco.Rua = endereco.Rua;
                clienteEndereco.Bairro= endereco.Bairro;
                clienteEndereco.Cidade= endereco.Cidade;
                clienteEndereco.Estado= endereco.Estado;
                conexao.SaveChanges();
                
            }
        }
        public void Deletar(int id) 
        {
        using(var conexao = new Contexto())
            {
               var enderecos = conexao.Enderecos.Where(x=> x.Id==id).FirstOrDefault();
                conexao.Enderecos.Remove(enderecos);
                conexao.SaveChanges();


            }
        
        }
    }
}
