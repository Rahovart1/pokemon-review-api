using pokemon.api.Models;

namespace pokemon.api.Interfaces
{
    public interface ICategoryRepository
    {
        Category GetCategoryById(int id);
        ICollection<Category> GetAll();
        ICollection<Pokemon> GetPokemonByCategory(int categoryId);
        bool CategoryExist(int id);

    }
}
