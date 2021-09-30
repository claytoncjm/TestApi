using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContatoApi.Models
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string Local { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}