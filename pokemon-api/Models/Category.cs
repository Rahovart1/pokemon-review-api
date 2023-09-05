namespace pokemon.api.Models
{
    public class Category : BaseEntity 
    {
        public string Name { get; set; }
        public ICollection<PokemonCategory> PokemonCategories { get; set; }
    }
}
