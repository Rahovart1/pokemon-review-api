using pokemon.api.Data;
using pokemon.api.Interfaces;
using pokemon.api.Models;

namespace pokemon.api.Repository
{
    public class ReviewRepository : RepositoryBase, IReviewRepository
    {
        public ReviewRepository(AppDbContext context) : base(context) {}


        public ICollection<Review> GetAll()
        {
            return _context.Reviews.OrderBy(r => r.Id).ToList();
        }

        public Review GetReview(int id)
        {
            return _context.Reviews.Where(r => r.Id == id).FirstOrDefault();
        }

        public ICollection<Review> GetReviewsByPokemon(int pokeid)
        {
            return _context.Reviews.Where(r => r.Pokemon.Id == pokeid).ToList();
        }

        public bool ReviewExist(int id)
        {
            return _context.Reviews.Any(r => r.Id == id);
        }

        public bool Create(Review review)
        {
            _context.Add(review);
            return Save();
        }
        
        public bool Update(Review review)
        {
            _context.Update(review);
            return Save();
        }
        public bool Delete(Review review)
        {
            _context.Remove(review);
            return Save();
        }

        public bool DeleteAll(List<Review> reviews)
        {
            _context.RemoveRange(reviews);
            return Save();
        }
    }
}
