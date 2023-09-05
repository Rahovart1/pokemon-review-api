namespace pokemon.api.Models
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Owner> Owners { get; set; }
    }
}
