using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreMysql.Models
{
    [Table("usuario")]
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
        public string ativo { get; set; }
        public string nivel { get; set; }

    }
}
