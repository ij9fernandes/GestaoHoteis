using Microsoft.EntityFrameworkCore;
using GestaoHoteis.Models;

namespace GestaoHoteis.Data
{

    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<ContatoModel> Contatos { get; set; }
    }
}