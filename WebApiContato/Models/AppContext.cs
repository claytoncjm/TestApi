using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiContato.Models
{
    public class AppContext : DbContext
    {
       public AppContext () : base("ContatoContext")
        { }

        public DbSet <Contato> Contatos { get; set; }
        public DbSet <Endereco> Enderecos { get; set; }
    }
}

// Na classe de contexto acima, as propriedades Contatos e Enderecos do tipo DbSet <TEntity> são chamadas de conjuntos de entidades.
// O EF Core irá mapear as entidades Contato e Endereco para as tabelas Contatos e Enderecos no banco de dados; se você usar o Migrations essas
// tabelas serão criadas no banco de dados