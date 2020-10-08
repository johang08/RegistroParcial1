using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroParcial1_JohanLuis.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Articulo> Persona { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}
