using AutoMapper;
using ProdutosAPI.Dtos;
using ProdutosAPI.Models;
using ProdutosAPI.Repositories.Abstract;
using ProdutosAPI.Services.Abstract;

namespace ProdutosAPI.Services
{
    public class ProdutoServ : IProdutoServ
    {
        private readonly IProdutoRepo _produtoRepo;
        private readonly IMapper _mapper;

        public ProdutoServ(IProdutoRepo produtoRepo, IMapper mapper)
        {
            _produtoRepo = produtoRepo;
            _mapper = mapper;
        }

        public async Task AddAsync(ProdutoDTO produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            await _produtoRepo.AddAsync(produto);
            produtoDto.SetNewId(produto.ProdutoId);
        }

        public async Task DeleteAsync(int id)
        {
            await _produtoRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            return await _produtoRepo.GetAllAsync();
        }

        public async Task<Produto?> GetByIdAsync(int id)
        {
            return await _produtoRepo.GetByIdAsync(id);
        }

        public async Task PatchAsync(int id, float preco)
        {
            await _produtoRepo.PatchAsync(id, preco);
        }

        public async Task UpdateAsync(int id, ProdutoDTO produtoDto)
        {
            var produto = await _produtoRepo.GetByIdAsync(id);
            if (produto == null)
            {
                throw new KeyNotFoundException($"Produto com ID {id} não encontrado.");
            }
            produtoDto.SetNewId(id);
            _mapper.Map(produtoDto, produto);
            await _produtoRepo.UpdateAsync(produto);
        }
    }
}
