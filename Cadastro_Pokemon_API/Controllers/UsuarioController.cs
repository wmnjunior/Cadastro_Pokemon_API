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

    public class UsuarioController : ApiController
    {
        //variavel estatica, para não resetar os dados quando nós fizermos as rotas
        static private readonly UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();

        //rota para adicionar um novo usuário, recebe um usuario serializado em JSON
        [HttpPost]
        public IHttpActionResult Adicionar([FromBody] Usuarios usuario)
        {
            try
            {
                //chama a camada de aplciação para adicionar o usuário
                var sucesso = usuarioAplicacao.Adicionar(usuario);

                if (sucesso)
                {
                    return Ok("Usuário Inserido com sucesso.");
                }
                else
                {
                    return BadRequest("Não conseguimos inseir o usuário. Por favor tente novamente");
                }

            }
            catch (Exception e)
            {
                return BadRequest("Ocorreu algum erro, por favor tente novamente.");
            }
        }

        //rota para alterar um usuário existente, recebe um usuario serializado em JSON
        [HttpPut]
        public IHttpActionResult Alterar([FromBody] Usuarios usuario)
        {
            try
            {
                //chama a camada de aplciação para alterar o usuário
                var sucesso = usuarioAplicacao.Alterar(usuario);

                if (sucesso)
                {
                    return Ok("Usuário Atualizado com sucesso.");
                }
                else
                {
                    return BadRequest("Não conseguimos atualizar o usuário. Por favor tente novamente");
                }
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu algum erro, por favor tente novamente.");
            }
        }

        //rota para alterar um usuário existente, recebe um usuario serializado em JSON
        [HttpPut]
        public IHttpActionResult AlterarSalarioTodos([FromBody] Usuarios usuario)
        {
            try
            {
                //chama a camada de aplciação para alterar o usuário
                var sucesso = usuarioAplicacao.AlterarSalarioTodos(usuario);

                if (sucesso)
                {
                    return Ok("Todos os Salarios Alterados com Sucesso!");
                }
                else
                {
                    return BadRequest("Nao conseguimos alterar todos os usuarios");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //rota para deletar um usuário existente, recebe o id do usuario que será deletado
        [HttpDelete]
        public IHttpActionResult Remover([FromBody] int idUsuario)
        {
            try
            {
                //chama a camada de aplciação para deletar o usuário
                var sucesso = usuarioAplicacao.Remover(idUsuario);

                if (sucesso)
                {
                    return Ok("Usuário Removido com sucesso.");
                }
                else
                {
                    return BadRequest("Não conseguimos remover o usuário. Por favor tente novamente");
                }
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu algum erro, por favor tente novamente.");
            }
        }

        //rota para exibir um usuário existente, recebe o id do usuario que será retornado
        [HttpPost]
        public IHttpActionResult ExibirUsuario([FromBody] int idUsuario)
        {
            try
            {
                //chama a camada de aplicação para retornar um usuário
                var usuarioRetornar = usuarioAplicacao.ExibirUsuario(idUsuario);
                if (usuarioRetornar != null)
                {
                    //caso o usuário exista, ele transforma o usuário em um documento json e o retorna
                    var usuarioSerializado = JsonConvert.SerializeObject(usuarioRetornar);
                    return Ok(usuarioSerializado);
                }
                else
                {
                    return BadRequest("Nenhum usuário foi encontrado com esse ID, por favor, tente novamente.");
                }
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu algum erro, por favor tente novamente.");
            }
        }

        [HttpPost]
        public IHttpActionResult BuscarNome([FromBody] Usuarios idUsuario)
        {
            try
            {
                //chama a camada de aplicação para retornar um usuário
                var usuarioRetornar = usuarioAplicacao.BuscarNome(idUsuario);
                if (usuarioRetornar != null)
                {

                    //caso o usuário exista, ele transforma o usuário em um documento json e o retorna
                    var usuarioSerializado = JsonConvert.SerializeObject(usuarioRetornar);
                    return Ok(usuarioSerializado);
                }
                else
                {
                    return BadRequest("Nome nao encontrado, favor buscar novamente");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public IHttpActionResult BuscarEmail([FromBody] Usuarios idUsuario)
        {
            try
            {
                //chama a camada de aplicação para retornar um usuário
                var usuarioRetornar = usuarioAplicacao.BuscarEmail(idUsuario);
                if (usuarioRetornar != null)
                {

                    //caso o usuário exista, ele transforma o usuário em um documento json e o retorna
                    var usuarioSerializado = JsonConvert.SerializeObject(usuarioRetornar);
                    return Ok(usuarioSerializado);
                }
                else
                {
                    return BadRequest("Email nao encontrado, favor buscar novamente");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult ExibirTodos()
        {
            try
            {
                //pega TODOS os usuário da camada aplicação
                var usuarios = usuarioAplicacao.ExibirTodos();

                if (usuarios != null)
                {
                    //se ele conseguir pegar todos os usuário ele transforma essa lista de usuarios em JSON e retorna
                    var usuariosSerializados = JsonConvert.SerializeObject(usuarios);
                    return Ok(usuariosSerializados);
                }
                else
                {
                    return BadRequest("Nenhum usuário cadastrado!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public IHttpActionResult BuscarPorFiltros([FromBody] Usuarios idusuarios)
        {
            try
            {
                //pega TODOS os usuário da camada aplicação
                var usuarioRetornar = usuarioAplicacao.BuscarPorFiltros(idusuarios);

                if (usuarioRetornar != null)
                {
                    //se ele conseguir pegar todos os usuário ele transforma essa lista de usuarios em JSON e retorna
                    var usuariosSerializados = JsonConvert.SerializeObject(usuarioRetornar);
                    return Ok(usuariosSerializados);
                }
                else
                {
                    return BadRequest("WEVERTON VAI GANHAR PRESENTE");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}