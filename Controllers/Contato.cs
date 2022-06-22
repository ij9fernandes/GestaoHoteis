using Microsoft.AspNetCore.Mvc;
using ControleDeContatos.Models;
using Repositorio;

namespace GestaoHoteis.Controllers
{
    public class Contato : Controller
    {
        // Declaração de variavel
        private readonly IContatoRepositorio _contatoRepositorio;

        // Observação quando ao nome do construtor: Contato ou ContatoRepositorio
        public Contato(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Criar()
        {
            return View();
        }
        
        public IActionResult Editar()
        {
            return View();
        }
        
        public IActionResult ApagarConfirmacao()
        {
            return View();
        }

        // Criação do método Post, para receber e cadastrar informações
        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            _contatoRepositorio.Adicionar(contato);
            return RedirectToAction("Index");
        }
    }
}
