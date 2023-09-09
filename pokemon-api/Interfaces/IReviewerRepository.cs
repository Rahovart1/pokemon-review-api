using pokemon.api.Models;

namespace pokemon.api.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetAll();
        Reviewer GetReviewer(int id);
        ICollection<Review> GetReviewsByReviewer(int reviewerid);
        bool ReviewerExist(int id);
        bool Create(Reviewer reviewer);
        bool Update(Reviewer reviewer);
        bool Delete(Reviewer reviewer);
    }
}
