using Microsoft.EntityFrameworkCore;
using ProdutosAPI.Data;
using ProdutosAPI.Models;
using ProdutosAPI.Repositories.Abstract;

namespace ProdutosAPI.Repositories
{
    public class ProdutoRepo : IProdutoRepo
    {
        private readonly ConnectionContext _context;

        public ProdutoRepo(ConnectionContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto?> GetByIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task PatchAsync(int id, float preco)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                produto.Preco = preco;
                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Produto produto)
        {
            try
            {
                _context.Produtos.Update(produto);
                await _context.SaveChangesAsync();
            } catch (Exception e)
            {
                throw new Exception($"error: {e.Message}");
            }
        }
    }
}
