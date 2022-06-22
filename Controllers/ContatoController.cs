using Microsoft.AspNetCore.Mvc;
using GestaoHoteis.Models;
using Repositorio;
using System.Collections.Generic;

namespace GestaoHoteis.Controllers
{
    public class ContatoController : Controller
    {
        // Declaração de variavel
        private readonly IContatoRepositorio _contatoRepositorio;

        // Observação quando ao nome do construtor: Contato ou ContatoRepositorio
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();

            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        // Retorna para dentro da View, o cadastro baseado no Id do banco de dados
        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorID(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorID(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            _contatoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        // Criação do método Post, para receber e cadastrar informações
        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            _contatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index");
        }
        // Criação do método Post, para receber e cadastrar informações
        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            _contatoRepositorio.Atualizar(contato);
            return RedirectToAction("Index");
        }
    }
}
