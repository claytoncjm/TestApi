using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiContato.Models
{
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }
        [StringLength(150)]
        public string Local { get; set; }
        [StringLength(100)]
        public string Cidade { get; set; }
        [StringLength(100)]
        public string Estado { get; set; }
    }
}

//Nas propriedades de navegação Enderecos e Contato usamos a palavra virtual que permite que o Entity Framework crie um proxy em torno da propriedade virtual
//para que a propriedade possa suportar o lazy load e rastreamento de alterações mais eficiente.  o virtual é um relacionamento 1 para 1