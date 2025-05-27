using ProdutosAPI.Models;

namespace ProdutosAPI.Repositories.Abstract
{
    public interface IProdutoRepo
    {
        Task AddAsync(Produto produto);
        Task<Produto?> GetByIdAsync(int id);
        Task<IEnumerable<Produto>> GetAllAsync();
        Task UpdateAsync(Produto produto);
        Task PatchAsync(int id, float preco);
        Task DeleteAsync(int id);
    }
}
