using Apresentation.Models;
using Business;
using Business.model;

using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TresCamadasProjeto.Models;

namespace TresCamadasProjeto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServices _service;

        public HomeController(ILogger<HomeController> logger, IServices service)
        {
            _logger = logger;
            _service = service;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
       public IActionResult Cadastro() {
           
        return View();
        }
        [HttpPost]
        public IActionResult SalvarCadastro(TeladecadastroViewModel TelaCliente)
        {
            try
            {
                if (!(TelaCliente.CPF == null))
                {
                    var cliente = new DtoCliente()
                    {
                        CPF = TelaCliente.CPF,
                        Nome = TelaCliente.Nome,
                        Enderecos = new List<DtoEndereco>() as ICollection<DtoEndereco>   // NECESSARIO PARA CONVERTE O TIPO LIST EM Icollection

                    };
                    cliente.Enderecos.Add(new DtoEndereco()
                    {
                        Bairro = TelaCliente.Bairro,
                        Rua = TelaCliente.Rua,
                        Cidade = TelaCliente.Cidade,
                        Estado = TelaCliente.Estado
                    });

                    _service.Salvar(cliente);
                    ViewBag.Sucesso = true;

                }

                return View("Cadastro");

            }

            catch(Exception e) {
                Console.WriteLine(e.Message);
                return View("erro");
            }
        }

        public IActionResult Listar()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ListarEnderecos(string CPF)
        {
                if (!String.IsNullOrEmpty(CPF)) {
                var cliente = _service.RetornarLista(CPF);
                return View("Listar", cliente);
            }
            return View("Listar");
        }
        public IActionResult Editar(DtoEndereco endereco)
        {
            return View(endereco);
        }
        [HttpPost]
        public IActionResult EditarEnviar(DtoEndereco endereco)
        {
            if(endereco != null)
            {
                _service.Alterar(endereco);
                return View("listar");
            }
            return View(endereco);
        }
        
        public IActionResult Deletar(ModelViewDelete delete)
        {
            _service.Deletar(delete.Id);
            return RedirectToAction("ListarEnderecos","home",new { CPF = delete.CPF });
        }
    }
}