using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiContato.Models
{
    public class Contato
    {
        [Key]
        public int ContatoId { get; set; }
        [StringLength(100)]
        public string Nome { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(40)]
        public string Telefone { get; set; }
        [Required]
        public virtual Endereco Endereco { get; set; }
        public virtual int EnderecoId { get; set; }
    }
}