using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ApiAngular.Models
{
    public class bdAngularContext:DbContext
    {
        public bdAngularContext() : base("connAngular") { }

        public DbSet<Personnes> personnes { get; set; }

    }
}