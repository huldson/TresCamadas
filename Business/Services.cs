using Business.model;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Services : IServices
    {
        private readonly IRepository _repository;
        public Services(IRepository repository)
        {
            _repository = repository;
        }

        public void Salvar(DtoCliente cliente)
        {

            var ClienteParaDataAccess = new Cliente()
            {
                CPF = cliente.CPF,
                Nome = cliente.Nome,
                Enderecos = new List<Endereco>() as ICollection<Endereco>
            };
            foreach (var itemDto in cliente.Enderecos)
            {
                ClienteParaDataAccess.Enderecos.Add(new Endereco()
                {
                    Rua = itemDto.Rua,
                    Bairro = itemDto.Bairro,
                    Cidade = itemDto.Cidade,
                    Estado = itemDto.Estado


                });

            }
            _repository.Salvar(ClienteParaDataAccess);
        }
        public DtoCliente RetornarLista(string cpf)
        {
            var cliente = _repository.RetornarLista(cpf);
            DtoCliente clienteRetorno = new DtoCliente()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                CPF = cliente.CPF,
                Enderecos = new List<DtoEndereco>() as ICollection<DtoEndereco>
            };

            foreach(var item in cliente.Enderecos)
            {
                clienteRetorno.Enderecos.Add(new DtoEndereco()
                {   Id= item.Id,
                    ClienteId=cliente.Id,
                    Rua = item.Rua,
                    Cidade = item.Cidade,
                    Estado =item.Estado,
                    Bairro=item.Bairro
                });
            };
            return clienteRetorno;
        }
        public void Alterar(DtoEndereco dtoEndereco)
        {
            var endereco = new Endereco()
            {
                ClienteId = dtoEndereco.ClienteId,
                Id = dtoEndereco.Id,
                Rua = dtoEndereco.Rua,
                Bairro = dtoEndereco.Bairro,
                Cidade = dtoEndereco.Cidade,
                Estado = dtoEndereco.Estado

            };
            _repository.Alterar(endereco);
        }

        public void Deletar(int id)
        {
            _repository.Deletar(id);
        }
    }
}
