using System.ComponentModel.DataAnnotations;
using PokeDL;
using PokeModel;

namespace PokeBL
{
    public class PokemonBL : IPokemonBL
    {
        //================== Dependency Injection ====================
        private readonly IRepository<Pokemon> _pokeRepo;
        public PokemonBL(IRepository<Pokemon> p_pokeRepo)
        {
            _pokeRepo = p_pokeRepo;
        }

        public void AddAbilityToPokemon(Pokemon p_pokemon)
        {
            //Logic to update pokemon
            _pokeRepo.Update(p_pokemon);
        }

        //============================================================

        public void AddPokemon(Pokemon p_poke)
        {
            //Processing data
            //We randomize the potential stat we get when we add a pokemon to the database
            Random rand = new Random();
            p_poke.Health = rand.Next(50);

            //Checks if that pokemon name already exists
            Pokemon foundedpokemon = SearchPokemonByName(p_poke.Name);
            if (foundedpokemon == null)
            {
                _pokeRepo.Add(p_poke);
            }
            else
            {
                throw new ValidationException("Pokemon name already exist");
            }
        }

        public List<Pokemon> GetAllPokemon()
        {
            return _pokeRepo.GetAll();
        }

        public async Task<List<Pokemon>> GetAllPokemonAsync()
        {
            return await _pokeRepo.GetAllAsync();
        }

        public Pokemon SearchPokemonById(int p_id)
        {

            //Will return null or no value if no pokemon was found
            return _pokeRepo.GetAll().First(pokemon => pokemon.PokeID == p_id);
        }

        public Pokemon? SearchPokemonByName(string p_pokeName)
        { 
            try
            {
                return _pokeRepo.GetAll().First(pokemon => pokemon.Name == p_pokeName);
            }
            catch (System.InvalidOperationException)
            {
                return null;
            }
        }
        
    }
}