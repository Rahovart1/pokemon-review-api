﻿using pokemon.api.Models;

namespace pokemon.api.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetAll();
        Pokemon GetPokemonById(int id);
        Pokemon GetPokemonByName(string name);
        decimal GetPokemonRating(int pokeId);
        bool PokemonExist(int pokeId);
        bool Create(int ownerId, int categoryId, Pokemon pokemon);
        bool Update(Pokemon pokemon);
        bool Delete(Pokemon pokemon);        
    }
}
