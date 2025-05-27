using AutoMapper;
using ProdutosAPI.Dtos;
using ProdutosAPI.Models;
using ProdutosAPI.Repositories.Abstract;
using ProdutosAPI.Services.Abstract;

namespace ProdutosAPI.Services
{
    public class UsuarioServ : IUsuarioServ
    {
        private readonly IUsuarioRepo _usuarioRepo;
        private readonly IMapper _mapper;

        public UsuarioServ(IUsuarioRepo usuarioRepo, IMapper mapper)
        {
            _usuarioRepo = usuarioRepo;
            _mapper = mapper;
        }

        public async Task AddAsync(UsuarioDTO usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            await _usuarioRepo.AddAsync( usuario );
            usuarioDto.SetNewId(usuario.UsuarioId);
        }

        public async Task DeleteAsync(int id)
        {
            await _usuarioRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _usuarioRepo.GetAllAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _usuarioRepo.GetByIdAsync(id);
        }

        public async Task UpdateAsync(int id, UsuarioDTO usuarioDto)
        {
            var usuario = await _usuarioRepo.GetByIdAsync(id);
            if (usuario == null)
            {
                throw new KeyNotFoundException($"Usuário com {id} não encontrado.");
            }

            _mapper.Map(usuarioDto, usuario);
            await _usuarioRepo.UpdateAsync(usuario);
        }

        public async Task<Usuario?> LoginAsync(string email, string senha)
        {
            var usuarios = await _usuarioRepo.GetAllAsync();
            var usuario = usuarios.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && u.Senha == senha);
            return usuario;
        }
    }
}
