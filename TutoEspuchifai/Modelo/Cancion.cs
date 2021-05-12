using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TutoEspuchifai.Modelo
{
    [Table("Cancion")]
    public class Cancion
    {
        [Key]
        [Column("idCancion")]
        public int IdCancion { get; set; }

        [Column("nombre")]
        [Required]
        [StringLength(45)]
        public string Nombre { get; set; }

        public List<Reproduccion> Reproducciones { get; set; }
        public Cancion()
        {
            Reproducciones = new List<Reproduccion>();
        }

        internal void agregarReproduccion(Reproduccion repro)
        {
            Reproducciones.Add(repro);
        }
    }
}
