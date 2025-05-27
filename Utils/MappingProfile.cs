using AutoMapper;
using ProdutosAPI.Dtos;
using ProdutosAPI.Models;

namespace ProdutosAPI.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UsuarioDTO, Usuario>()
                .ReverseMap();
            CreateMap<ProdutoDTO, Produto>()
                .ReverseMap();
        }
    }
}
