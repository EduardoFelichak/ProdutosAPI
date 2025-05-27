using ProdutosAPI.Dtos;
using ProdutosAPI.Models;

namespace ProdutosAPI.Services.Abstract
{
    public interface IProdutoServ
    {
        Task AddAsync(ProdutoDTO produtoDto);
        Task<Produto?> GetByIdAsync(int id);
        Task<IEnumerable<Produto>> GetAllAsync();
        Task UpdateAsync(int id, ProdutoDTO produtoDto);
        Task PatchAsync(int id, float preco);
        Task DeleteAsync(int id);
    }
}
