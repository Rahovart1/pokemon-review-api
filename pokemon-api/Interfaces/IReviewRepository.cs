using pokemon.api.Models;

namespace pokemon.api.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetAll();
        Review GetReview(int id);
        ICollection<Review> GetReviewsByPokemon(int pokeid);
        bool ReviewExist(int id);
        bool Create(Review review);
        bool Update(Review review);
        bool Delete(Review review);
        bool DeleteAll(List<Review> review);
    }
}
