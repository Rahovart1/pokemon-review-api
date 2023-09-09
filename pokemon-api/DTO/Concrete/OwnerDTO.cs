using pokemon.api.DTO.Abstract;

namespace pokemon.api.DTO.Concrete
{
    public class OwnerDTO : DTOBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gym { get; set; }
    }
}
