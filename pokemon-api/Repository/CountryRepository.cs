using pokemon.api.Data;
using pokemon.api.Interfaces;
using pokemon.api.Models;
using pokemon.api.Repository;

namespace pokemon.api.Repository
{
    public class CountryRepository : RepositoryBase, ICountryRepository
    {
        public CountryRepository(AppDbContext context) : base(context) {}

        public bool CountryExist(int id)
        {
            return _context.Countries.Any(c => c.Id == id);
        }


        public ICollection<Country> GetAll()
        {
            return _context.Countries.OrderBy(c => c.Id).ToList();  
        }

        public Country GetCountryById(int id)
        {
            return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).Select(o => o.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromCountry(int countryId)
        {
            return _context.Owners.Where(c => c.Country.Id == countryId).ToList();
        }

        public bool Create(Country country)
        {
            _context.Add(country);
            return Save();
        }

        public bool Update(Country country)
        {
            _context.Update(country);
            return Save();
        }

        public bool Delete(Country country)
        {
            _context.Remove(country);
            return Save();
        }
    }
}
