using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using pokemon.api.Data;
using pokemon.api.Interfaces;
using pokemon.api.Models;

namespace pokemon.api.Repository
{
    public class ReviewerRepository : RepositoryBase, IReviewerRepository
    {
        public ReviewerRepository(AppDbContext context) : base(context) {}

        public ICollection<Reviewer> GetAll()
        {
            return _context.Reviewers.OrderBy(r => r.Id).ToList();
        }

        public Reviewer GetReviewer(int id)
        {
            return _context.Reviewers.Where(r => r.Id == id).Include(e => e.Reviews).FirstOrDefault();
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerid)
        {
            return _context.Reviews.Where(r => r.Reviewer.Id == reviewerid).ToList();
        }

        public bool ReviewerExist(int id)
        {
            return _context.Reviewers.Any(r => r.Id == id);
        }

        public bool Create(Reviewer reviewer)
        {
            _context.Add(reviewer);
            return Save();
        }

        public bool Update(Reviewer reviewer)
        {
            _context.Update(reviewer);
            return Save();
        }

        public bool Delete(Reviewer reviewer)
        {
            _context.Remove(reviewer);
            return Save();
        }
    }
}
