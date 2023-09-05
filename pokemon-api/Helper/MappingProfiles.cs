using AutoMapper;
using pokemon.api.DTO;
using pokemon.api.Models;

namespace pokemon.api.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDTO>();
            CreateMap<Category, CategoryDTO>();
        }
    }
}
