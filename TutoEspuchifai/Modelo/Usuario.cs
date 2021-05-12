using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TutoEspuchifai.Modelo
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [Column("idUsuario")]
        public int IdUsuario { get; set; }

        [Column("nombreUsuario")]
        [Required]
        [StringLength(30)]
        public string NombreUsuario { get; set; }

        [Column("password")]
        [Required]
        [StringLength(45)]
        public string Password { get; set; }

        public List<Reproduccion> Reproducciones { get; set; }

        public Usuario()
        {
            Reproducciones = new List<Reproduccion>();
        }

        internal void agregarReproduccion(Reproduccion repro)
        {
            Reproducciones.Add(repro);
        }

        public void reproducirCancion(Cancion cancion)
        {
            var reproduccion = new Reproduccion(this, cancion);
            agregarReproduccion(reproduccion);
            cancion.agregarReproduccion(reproduccion);
        }


    }
}
