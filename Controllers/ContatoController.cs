﻿using Microsoft.AspNetCore.Mvc;
using GestaoHoteis.Models;
using Repositorio;
using System.Collections.Generic;

namespace GestaoHoteis.Controllers
{
    public class ContatoController : Controller
    {
       
        private readonly IContatoRepositorio _contatoRepositorio;

        
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
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);
                
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não foi possível excluir o contato!";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível cadastrar seu contato, tente novamente, detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato Cadastrado com Sucesso!";
                    return RedirectToAction("Index");
                }
                
                return View(contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível realizar o cadastro, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");

            }
        }
        
        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
           try
           {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }
            
                return View("Editar", contato);
           }
           catch (System.Exception erro)
           {
            
                TempData["MensagemErro"] = $"Ops, não foi possível atualizar seu contato, tente novamente, detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
           } 
        }
    }
}
