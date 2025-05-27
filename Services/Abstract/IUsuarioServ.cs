using ProdutosAPI.Dtos;
using ProdutosAPI.Models;

namespace ProdutosAPI.Services.Abstract
{
    public interface IUsuarioServ
    {
        Task AddAsync(UsuarioDTO usuarioDto);
        Task<Usuario?> GetByIdAsync(int id);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task UpdateAsync(int id, UsuarioDTO usuarioDto);
        Task DeleteAsync(int id);
        Task<Usuario?> LoginAsync(string email, string senha);
    }
}
