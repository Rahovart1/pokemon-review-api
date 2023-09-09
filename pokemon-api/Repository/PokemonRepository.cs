using Microsoft.EntityFrameworkCore;
using pokemon.api.Data;
using pokemon.api.Interfaces;
using pokemon.api.Models;

namespace pokemon.api.Repository
{
    public class PokemonRepository : RepositoryBase, IPokemonRepository
    {
        public PokemonRepository(AppDbContext context) : base(context) {}


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

        public bool Create(int ownerId, int categoryId, Pokemon pokemon)
        {
            var pokemonOwnerEntity = _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
            var category = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();

            var pokeOwner = new PokemonOwner()
            {
                Owner = pokemonOwnerEntity,
                Pokemon = pokemon,
            };

            _context.Add(pokeOwner);

            var pokemonCategory = new PokemonCategory()
            {
                Category = category,
                Pokemon = pokemon,
            };
            
            _context.Add(pokemonCategory);

            _context.Add(pokemon);

            return Save();
        }

        public bool Update(Pokemon pokemon)
        {
            _context.Update(pokemon);
            return Save();
        }
        public bool Delete(Pokemon pokemon)
        {
            _context.Remove(pokemon);
            return Save();
        }
    }
}