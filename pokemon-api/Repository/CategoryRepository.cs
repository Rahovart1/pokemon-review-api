using pokemon.api.Data;
using pokemon.api.Interfaces;
using pokemon.api.Models;

namespace pokemon.api.Repository
{
    public class CategoryRepository : RepositoryBase, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) {}
        public bool CategoryExist(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }


        public Category GetCategoryById(int id)
        {
            return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(p => p.CategoryId == categoryId).Select(p => p.Pokemon).ToList();
        }
        public ICollection<Category> GetAll()
        {
            return _context.Categories.OrderBy(c => c.Id).ToList();
        }

        public bool Create(Category category)
        {
            _context.Add(category);
            return Save();
        }
        public bool Update(Category category)
        {
            _context.Update(category);
            return Save();
        }

        public bool Delete(Category category)
        {
            _context.Remove(category);
            return Save();
        }

    }
}
