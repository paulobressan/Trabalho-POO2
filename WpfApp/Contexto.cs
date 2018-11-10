using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.model;

namespace WpfApp
{
    public class Contexto : DbContext
    {
        public Contexto(): base(nameOrConnectionString : "conexao")
        {
            Database.SetInitializer<Contexto>(new ContextoApp());
        }
        public DbSet<Produto> Produtos { get; set; }
    }
    public class ContextoApp : DropCreateDatabaseAlways<Contexto>
    {

    }
}
