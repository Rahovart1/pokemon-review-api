using AutoMapper;
using pokemon.api.DTO.Concrete;
using pokemon.api.Models;

namespace pokemon.api.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Reviewer, ReviewerDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap(); ;
            CreateMap<Pokemon, PokemonDTO>().ReverseMap(); ;
            CreateMap<Country, CountryDTO>().ReverseMap(); ;
            CreateMap<Review, ReviewDTO>().ReverseMap(); ;
            CreateMap<Owner, OwnerDTO>().ReverseMap(); ;
            
            //CreateMap<ReviewerDTO, Reviewer>();
            //CreateMap<CategoryDTO, Category>();
            //CreateMap<PokemonDTO, Pokemon>();
            //CreateMap<CountryDTO, Country>();
            //CreateMap<ReviewDTO, Review>();
            //CreateMap<OwnerDTO, Owner>();
        }
    }
}
