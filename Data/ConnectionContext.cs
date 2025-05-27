using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations.Rules;
using ProdutosAPI.Models;

namespace ProdutosAPI.Data
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options) { }
    }
}
