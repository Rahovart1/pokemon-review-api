using pokemon.api.Models;

namespace pokemon.api.Interfaces
{
    public interface ICountryRepository
    {
        Country GetCountry(int id);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersFromCountry(int countryId);
        ICollection<Country> GetAll();
        bool CountryExist(int id);

    }
}
