using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cadastro_Pokemon_API.Models
{
    public class Moves
    {
        [Key]
        public int id { get; set; }
        public string valor_moves { get; set; }
        [ForeignKey("Pokemon")]
        public int pokemon_id { get; set; }
        [JsonIgnore]
        public virtual Pokemon Pokemon { get; set; }
    }
}