using ProdutosAPI.Models;

namespace ProdutosAPI.Repositories.Abstract
{
    public interface IUsuarioRepo
    {
        Task AddAsync(Usuario usuario);
        Task<Usuario?> GetByIdAsync(int id);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);
    }
}
