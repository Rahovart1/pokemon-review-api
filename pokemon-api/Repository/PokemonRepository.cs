using Microsoft.EntityFrameworkCore;
using pokemon.api.Data;
using pokemon.api.Interfaces;
using pokemon.api.Models;

namespace pokemon.api.Repository
{
    public class PokemonRepository : RepositoryBase, IPokemonRepository
    {
        public PokemonRepository(AppDbContext context) : base(context)
        {
        }

        public Pokemon GetPokemonById(int id)
        {
           return _context.Pokemons.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemonByName(string name)
        {
            return _context.Pokemons.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeId)
        {
            var review = _context.Reviews.Where(p => p.Pokemon.Id == pokeId);

            if (!review.Any())
                return 0;

            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        public bool PokemonExist(int pokeId)
        {
            return _context.Pokemons.Any(p => p.Id == pokeId);  
        }
        public ICollection<Pokemon> GetAll()
        {
            return _context.Pokemons.OrderBy(p => p.Id).ToList();
        }
    }
}