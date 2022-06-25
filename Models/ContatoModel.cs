using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GestaoHoteis.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Nome é obrigatório")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage="Email é obrigatório")]
        [EmailAddress(ErrorMessage="Email informado não é válido")]
        public string Email { get; set; }
        
        [Required(ErrorMessage="Celular obrigatório")]
        [Phone(ErrorMessage="Celular informado não é válido")]
        public string Celular { get; set; }
    }
}
