using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cadastro_Pokemon_API.Models
{
    public class Pokemon
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string imagem { get; set; }
        public int num_pokemon { get; set; }
        public virtual List<Status> Status { get; set; }
        public virtual List<Ability> Abilitys { get; set; }
        public virtual List<Moves> Moves { get; set; }
    }
}