using Cadastro_Pokemon_API.Models;
using Cadastro_Pokemon_API.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqKit;

namespace Cadastro_Pokemon_API.Aplicacao
{
    public class UsuarioAplicacao
    {
        //criando o banco de dados fictio utilizando o modelo Usuario e adicionando 4 usuarios
        private List<Usuarios> Usuarios = new List<Usuarios>
        {

        };
        private string Id_Invalida = "ID_Invalida!";

        //método para adicionar um usuário na lista
        public bool Adicionar(Usuarios usuarioRecebido)
        {
            //atribui os dados a uma nova variavel
            // var usuarioInserir = usuarioRecebido;

            using (var ctx = new Repositorio())
            {
                ctx.Usuarios.Add(usuarioRecebido);
                ctx.SaveChanges();
                return true;
            }

            //pega o valor do ultimo id cadastrado precisa do -1 pois começa em zero
            // var ultimoIdCadastrado = usuarios[usuarios.Count - 1].Id;
            //adiciona +1 pois o id nao pode ser igual ao anterior
            /* usuarioInserir.Id = ultimoIdCadastrado + 1;

             try
             {
                 usuarios.Add(usuarioInserir);
                 return true;
             }
             catch (Exception)
             {
                 return false;
             }*/
        }


        //método para remover um usuário na lista através do Id utilizando LINQ
        public bool Remover(int id)
        {
            try
            {
                using (var ctx = new Repositorio())
                {
                    Usuarios _usuarios = ctx.Usuarios.Find(id);
                    ctx.Usuarios.Remove(_usuarios);
                    ctx.SaveChanges();
                    return true;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        //método para alterar os dados de um usuario
        public bool Alterar(Usuarios usuarioRecebido)
        {
            //como o id é automatico, caso o id passado não exista
            //joga uma exceção que é tratada no controller
            using (Repositorio ctx = new Repositorio())
            {
                if (usuarioRecebido.id > 0)
                {
                    Usuarios _usuarios = ctx.Usuarios.Find(usuarioRecebido.id);

                    if (_usuarios == null)
                        throw new Exception(Id_Invalida);


                    _usuarios.nome = usuarioRecebido.nome;
                    _usuarios.email = usuarioRecebido.email;
                    _usuarios.sexo = usuarioRecebido.sexo;
                    _usuarios.senha = usuarioRecebido.senha;
                    ctx.SaveChanges();
                    return true;
                }
                return true;

            }


        }
        //método para alterar os dados de um usuario
        public bool AlterarSalarioTodos(Usuarios usuarioRecebido)
        {
            //como o id é automatico, caso o id passado não exista
            //joga uma exceção que é tratada no controller
            //Using acessa banco de dados
            using (Repositorio ctx = new Repositorio())
            {
                //buscando objeto de usuarios
                var _usuarios = ctx.Usuarios.ToList();

                _usuarios.ForEach(x => x.salario = usuarioRecebido.salario);

                ctx.SaveChanges(); //salvando no banco
                return true;
            }

        }

        //método para exibir todos os usuarios
        public List<Usuarios> ExibirTodos()
        {

            using (Repositorio ctx = new Repositorio())
            {
                return ctx.Usuarios.OrderBy(x => x.nome).ToList();
            }
        }
        //método que busca um usuario através do id e retorna.
        public Usuarios ExibirUsuario(int id)
        {
            using (Repositorio ctx = new Repositorio())
            {
                return ctx.Usuarios.Find(id);
            }
        }

        public List<Usuarios> BuscarNome(Usuarios usuario)
        {
            using (Repositorio ctx = new Repositorio())
            {
                return ctx.Usuarios // tolower.Contrais coloca tudo no minusculo para facilitar a busca]
                    .Where(x => x.nome.ToLower().Contains(usuario.nome
                        .Trim().ToLower())).ToList();
            }
        }

        public List<Usuarios> BuscarEmail(Usuarios usuario)
        {
            using (Repositorio ctx = new Repositorio())
            {
                return ctx.Usuarios // tolower.Contrais coloca tudo no minusculo para facilitar a busca]
                    .Where(x => x.nome.ToLower().Contains(usuario.email
                        .Trim().ToLower())).ToList();
            }
        }
        //Busca usuario por filtro, PredicateBuilder
        public List<Usuarios> BuscarPorFiltros(Usuarios usuarios)
        {

            using (Repositorio ctx = new Repositorio())
            {
                //tem que ser chamado toda vez que usa link
                ExpressionStarter<Usuarios> query = PredicateBuilder.New<Usuarios>();
                //entra no iff quando nao e vasio
                if (!string.IsNullOrEmpty(usuarios.nome))
                {   //consulta dentro do banco
                    query.And((x => x.nome.ToLower().Contains(usuarios.nome
                        .Trim().ToLower())));

                }
                if (!string.IsNullOrEmpty(usuarios.email))
                {
                    query.And((x => x.email.ToLower().Contains(usuarios.email
                       .Trim().ToLower())));
                }
                if (usuarios.salario > 0)
                {
                    query.And(x => x.salario == usuarios.salario);
                }

                return ctx.Usuarios.Where(query).ToList();
            }

        }


    }
}