using pokemon.api.Data;
using pokemon.api.Interfaces;
using pokemon.api.Models;

namespace pokemon.api.Repository
{
    public class OwnerRepository : RepositoryBase, IOwnerRepository
    {
        public OwnerRepository(AppDbContext context) : base(context) {}

        public ICollection<Owner> GetAll()
        {
            return _context.Owners.OrderBy(o =>  o.Id).ToList();    
        }

        public Owner GetOwnerById(int id)
        {
            return _context.Owners.Where(o => o.Id == id).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersOfPokemon(int pokeId)
        {
            return _context.PokemonOwners.Where(p => p.Pokemon.Id == pokeId).Select(o => o.Owner).ToList();
        }

        public ICollection<Pokemon> GetPokemonsByOwner(int ownerId)
        {
            return _context.PokemonOwners.Where(p => p.Owner.Id == ownerId).Select(p => p.Pokemon).ToList();
        }

        public bool OwnerExist(int ownerId)
        {
            return _context.Owners.Any(o => o.Id == ownerId);
        }

        public bool Create(Owner owner)
        {
            _context.Add(owner);
            return Save();
        }
        public bool Update(Owner owner)
        {
            _context.Update(owner);
            return Save();
        }

        public bool Delete(Owner owner)
        {
            _context.Remove(owner);
            return Save();
        }
    }
}
