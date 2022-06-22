using GestaoHoteis.Data;
using GestaoHoteis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorio
{
    // Implementação da interface Contato Repositório dentro da Classe Contato Repositório
    public class ContatoRepositorio : IContatoRepositorio
    {
        // Declaração de variável pública somente leitura _bancoContext
        private readonly BancoContext _bancoContext;

        // Injetar o BancoContext, que recebe o mesmo nome com inicia minuscula
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ContatoModel ListarPorID(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        // Método para adicionar contato
        public ContatoModel Adicionar(ContatoModel contato)
        {
            // Grava contato no banco de dados
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorID(contato.Id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na atualização do contato!");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarPorID(id);

            if (contatoDB == null) throw new System.Exception("Houve um erro ao deletar contato!");

            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();

            return true;

        }
    }
}
