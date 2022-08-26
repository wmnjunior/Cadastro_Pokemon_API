using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cadastro_Pokemon_API.Models
{
    public class Status
    {
        [Key]
        public int id { get; set; }
        public string status { get; set; }
        public int valor_status { get; set; }
        [ForeignKey("Pokemon")]
        public int pokemon_id { get; set; }
        [JsonIgnore]
        public virtual Pokemon Pokemon { get; set; }
    }
}