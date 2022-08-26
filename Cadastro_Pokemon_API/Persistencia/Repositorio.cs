using Cadastro_Pokemon_API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cadastro_Pokemon_API.Persistencia
{

    public class Repositorio : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Ability> Abilitys { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Moves> Moves { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(schema: "public");
            /* modelBuilder.Properties().Configure(c =>
             {
                 var name = c.ClrPropertyInfo.Name;
                 c.HasColumnName(name.ToLower());
             });*/


            //Direcionando para a Tabela usuario no PostGreSQL
            modelBuilder.Entity<Usuarios>().ToTable("usuarios");

            //Pokemon direcionando para Tabelas:
            modelBuilder.Entity<Pokemon>().ToTable("pokemon");
            modelBuilder.Entity<Ability>().ToTable("ability");
            modelBuilder.Entity<Status>().ToTable("status");
            modelBuilder.Entity<Moves>().ToTable("moves");
        }
    }


}