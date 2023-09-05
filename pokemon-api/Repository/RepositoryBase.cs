using pokemon.api.Data;

namespace pokemon.api.Repository
{
    public class RepositoryBase
    {
        protected readonly AppDbContext _context;
        public RepositoryBase(AppDbContext context)
        {
            _context = context;
        }
    }
}
