using DisqueraAlbumes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisqueraAlbumes.Domain.Contexto
{
    public class DisqueraAlbumesContext:DbContext
    {

        public DisqueraAlbumesContext() : base("DisqueraDB")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        //tabla usaremos > colecciones
        public DbSet<Album> Albumes { get; set; } //Alias en plural para buscar en la base de datos
    }
}

