using Cadastro_Pokemon_API.Models;
using Cadastro_Pokemon_API.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqKit;
using System.Data.Entity;

namespace Cadastro_Pokemon_API.Aplicacao
{
    public class PokemonAplicacao
    {
        public bool AdicionarPokemon(Pokemon pokemonRecedido)
        {
            using (var ctx = new Repositorio())
            {
                ctx.Pokemons.Add(pokemonRecedido);
                ctx.SaveChanges();
                /* if (pokemonRecedido.Abilitys != null && pokemonRecedido.Abilitys.Count > 0)
                 {
                     List<Ability> auxAbilit = new List<Ability>();
                     foreach (var ability in pokemonRecedido.Abilitys)
                     {
                         Ability novaAbility = new Ability
                         {
                             ability = ability.ability,
                             pokemon_id = pokemonRecedido.id
                         };
                         auxAbilit.Add(novaAbility);
                     }
                     pokemonRecedido.Abilitys = auxAbilit;
                     ctx.SaveChanges();
                 }
                 if (pokemonRecedido.Status  != null && pokemonRecedido.Status.Count > 0)
                 {
                     foreach (var status in pokemonRecedido.Status)
                     {
                         Status novoStatus = new Status
                         {
                             status = status.status,
                             valor_status = status.valor_status,
                             pokemon_id = status.pokemon_id
                         };
                     }
                 }
                 if (pokemonRecedido.Moves != null && pokemonRecedido.Moves.Count > 0)
                 {
                     foreach (var moves in pokemonRecedido.Moves)
                     {
                         Moves novoMoves = new Moves
                         {
                             valor_moves = moves.valor_moves,
                             pokemon_id = moves.pokemon_id
                         };
                     }
                 } */

                return true;
            }
        }
        public bool RemoverPokemon(int id)
        {
            try
            {
                using (var ctx = new Repositorio())
                {
                    Pokemon _pokemon = ctx.Pokemons.Find(id);
                    ctx.Abilitys.RemoveRange(_pokemon.Abilitys);
                    ctx.Status.RemoveRange(_pokemon.Status);
                    ctx.Moves.RemoveRange(_pokemon.Moves);
                    ctx.Pokemons.Remove(_pokemon);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public Pokemon ExibirPokemon(int IdPokemon)
        {
            using (Repositorio ctx = new Repositorio())
            {
                return ctx.Pokemons
                    .Include(x => x.Abilitys)
                    .Include(x => x.Status)
                    .Include(x => x.Moves)
                    .Where(x => x.id == IdPokemon).FirstOrDefault();
            }
        }
        //Busca Pokemon por filtro, PredicateBuilder
        public List<Pokemon> BuscarPorFiltros(Pokemon pokemonRecedido)
        {

            using (Repositorio ctx = new Repositorio())
            {
                //tem que ser chamado toda vez que usa link
                ExpressionStarter<Pokemon> query = PredicateBuilder.New<Pokemon>();
                //entra no iff quando nao e vasio
                if (!string.IsNullOrEmpty(pokemonRecedido.name))
                {   //consulta dentro do banco
                    query.And((x => x.name.ToLower().Contains(pokemonRecedido.name
                        .Trim().ToLower())));
                }
                if (pokemonRecedido.num_pokemon > 0)
                {
                    query.And(x => x.num_pokemon == pokemonRecedido.num_pokemon);
                }

                return ctx.Pokemons.Include(x => x.Abilitys)
                    .Include(x => x.Status)
                    .Include(x => x.Moves).Where(query).ToList();
            }

        }

    }
}