using pokemon.api.Models;

namespace pokemon.api.Interfaces
{
    public interface ICountryRepository
    {
        Country GetCountryById(int id);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersFromCountry(int countryId);
        ICollection<Country> GetAll();
        bool CountryExist(int id);
        bool Create(Country country);
        bool Update(Country country);
        bool Delete(Country country);
    }
}
