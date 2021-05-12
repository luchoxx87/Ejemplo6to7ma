using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TutoEspuchifai.Modelo
{
    [Table("Reproduccion")]
    public class Reproduccion
    {
        [Key]
        [Column("idReproduccion")]
        public int IdReproduccion { get; set; }

        [ForeignKey("idUsuario")]
        [Required]
        public Usuario Usuario { get; set; }

        [ForeignKey("idCancion")]
        [Required]
        public Cancion Cancion { get; set; }

        [Column("fechaHora")]
        public DateTime FechaHora { get; set; }

        public Reproduccion(Usuario usuario, Cancion cancion): this()
        {
            this.Usuario = usuario;
            this.Cancion = cancion;
        }

        public Reproduccion()
        {
            FechaHora = DateTime.Now;
        }
    }
}