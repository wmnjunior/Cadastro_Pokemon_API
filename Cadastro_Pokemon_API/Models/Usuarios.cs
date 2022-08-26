using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cadastro_Pokemon_API.Models
{
    public class Usuarios
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string sexo { get; set; }
        public int salario { get; set; }
        public string senha { get; set; }
    }
}