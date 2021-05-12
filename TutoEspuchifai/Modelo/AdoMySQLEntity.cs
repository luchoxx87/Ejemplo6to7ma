using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TutoEspuchifai.Modelo
{
    class AdoMySQLEntity: DbContext
    {
        public DbSet<Cancion> Canciones { get; set; }
        public DbSet<Reproduccion> Reproducciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=espuchi;user=root;password=12Lujho");
        }

        public List<Reproduccion> getReproducciones() => Reproducciones.Include(r => r.Cancion)
                                                        .Include(r => r.Usuario)
                                                         .ToList();

        public List<Reproduccion> getReproducciones(Cancion cancion) => Reproducciones
                    .Where(r => r.Cancion.IdCancion == cancion.IdCancion)
                    .ToList();
    }
}