using pokemon.api.Models;

namespace pokemon.api.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetAll();
        ICollection<Owner> GetOwnersOfPokemon(int pokeId);
        ICollection<Pokemon> GetPokemonsByOwner(int ownerId);
        Owner GetOwnerById(int id);
        bool OwnerExist(int ownerId);
        bool Create(Owner owner);
        bool Update(Owner owner);
        bool Delete(Owner owner);
    }
}
