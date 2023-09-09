using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using pokemon.api.DTO.Concrete;
using pokemon.api.Interfaces;
using pokemon.api.Models;
using pokemon.api.Repository;

namespace pokemon.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper, IOwnerRepository ownerRepository, IReviewRepository reviewRepository)
        {
            _pokemonRepository = pokemonRepository;
            _ownerRepository = ownerRepository; 
            _reviewRepository= reviewRepository; 
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var pokemons = _mapper.Map<List<PokemonDTO>>(_pokemonRepository.GetAll());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemons);
        }

        [HttpGet("{pokeId}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int pokeId)
        {
            if (!_pokemonRepository.PokemonExist(pokeId))
                return NotFound();

            var pokemon = _mapper.Map<PokemonDTO>(_pokemonRepository.GetPokemonById(pokeId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemon);
        }

        [HttpGet("{pokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int pokeId)
        {
            if (!_pokemonRepository.PokemonExist(pokeId))
                return NotFound();

            var rating = _pokemonRepository.GetPokemonRating(pokeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(rating);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePokemon([FromQuery] int ownerId, [FromQuery] int catId, [FromBody] PokemonDTO pokemonCreate)
        {
            if (pokemonCreate == null)
                return BadRequest(ModelState);

            //var pokemons = _pokemonRepository.GetPokemonTrimToUpper(pokemonCreate);
            var pokemons = _pokemonRepository.GetAll()
                .Where(p => p.Name.Trim().ToUpper() == pokemonCreate.Name.Trim().ToUpper())
                .FirstOrDefault();

            if (pokemons != null)
            {
                ModelState.AddModelError("", "Owner already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pokemonMap = _mapper.Map<Pokemon>(pokemonCreate);

            if (!_pokemonRepository.Create(ownerId, catId, pokemonMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePokemon([FromQuery] int pokeId, [FromBody] PokemonDTO updatePokemon)
        {
            if (updatePokemon == null)
                return BadRequest(ModelState);

            if (pokeId != updatePokemon.Id)
                return BadRequest(ModelState);

            if (!_pokemonRepository.PokemonExist(pokeId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var pokeMap = _mapper.Map<Pokemon>(updatePokemon);
            pokeMap.BirthDate = DateTime.Now;

            if (!_pokemonRepository.Update(pokeMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{pokeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePokemon(int pokeId)
        {
            if (!_pokemonRepository.PokemonExist(pokeId))
                return NotFound();

            var pokemon = _pokemonRepository.GetPokemonById(pokeId);
            var reviews = _reviewRepository.GetReviewsByPokemon(pokeId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_reviewRepository.DeleteAll(reviews.ToList()))
            {
                ModelState.AddModelError("", "Something went wrong while deleting reviews");
                return StatusCode(500, ModelState);
            }


            if (!_pokemonRepository.Delete(pokemon))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
