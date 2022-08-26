using Cadastro_Pokemon_API.Aplicacao;
using Cadastro_Pokemon_API.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cadastro_Pokemon_API.Controllers
{

    public class PokemonController : ApiController
    {
        //variavel estatica, para não resetar os dados quando nós fizermos as rotas
        static private readonly PokemonAplicacao pokemonAplicacao = new PokemonAplicacao();
        [HttpPost]
        public IHttpActionResult AdicionarPokemon([FromBody] Pokemon pokemon)
        {
            try
            {
                //chama a camada de aplciação para adicionar o usuário
                var sucesso = pokemonAplicacao.AdicionarPokemon(pokemon);

                if (sucesso)
                {
                    return Ok("Pokemon Inserido com sucesso.");
                }
                else
                {
                    return BadRequest("Não conseguimos inseir o Pokemon. Por favor tente novamente");
                }

            }
            catch (Exception e)
            {
                return BadRequest("erro, por favor tente novamente.");
            }
        }
        [HttpDelete]
        public IHttpActionResult RemoverPokemon([FromBody] int idPokemon)
        {
            try
            {
                //chama a camada de aplciação para deletar o usuário
                var sucesso = pokemonAplicacao.RemoverPokemon(idPokemon);

                if (sucesso)
                {
                    return Ok("Pokemon Removido com sucesso.");
                }
                else
                {
                    return BadRequest("Não conseguimos remover o Pokemon. Por favor tente novamente");
                }
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu algum erro, por favor tente novamente.");
            }

        }
        [HttpPost]
        public IHttpActionResult ExibirPokemon([FromBody] int IdPokemon)
        {
            try
            {
                //chama a camada de aplicação para retornar um pokemon
                var pokemonRetornar = pokemonAplicacao.ExibirPokemon(IdPokemon);
                if (pokemonRetornar != null)
                {
                    //caso o usuário exista, ele transforma o pokemon em um documento json e o retorna
                    var pokemonSerializado = JsonConvert.SerializeObject(pokemonRetornar);
                    return Ok(pokemonSerializado);
                }
                else
                {
                    return BadRequest("Nenhum pokemon foi encontrado com esse ID, por favor, tente novamente.");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Ocorreu algum erro, por favor tente novamente.");
            }
        }
        [HttpPost]
        public IHttpActionResult BuscarPorFiltros([FromBody] Pokemon pokemon)
        {
            try
            {
                //pega TODOS os usuário da camada aplicação
                var pokemonRetornar = pokemonAplicacao.BuscarPorFiltros(pokemon);

                if (pokemonRetornar != null)
                {
                    //se ele conseguir pegar todos os usuário ele transforma essa lista de usuarios em JSON e retorna
                    var pokemonSerializados = JsonConvert.SerializeObject(pokemonRetornar);
                    return Ok(pokemonSerializados);
                }
                else
                {
                    return BadRequest("Nenhum Pokemon Encontrado");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + "Deu Ruim ");
            }
        }
    }
}