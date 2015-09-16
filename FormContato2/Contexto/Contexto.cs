using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using FormContato2.Models;

namespace FormContato2.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto()
            : base("Contexto")
        {

        }

        public DbSet<FormularioModel> Formulario { get; set; }
    }
}