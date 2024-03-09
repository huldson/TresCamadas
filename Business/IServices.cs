﻿using Business.model;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IServices
    {
        public void Salvar(DtoCliente cliente);

        public DtoCliente RetornarLista(string cpf);

        public void Alterar(DtoEndereco dtoEndereco);

        public void Deletar(int id);
    }
}
