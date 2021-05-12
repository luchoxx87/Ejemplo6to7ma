using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TutoEspuchifai.Modelo;

namespace TutoEspuchifai
{
    class Program
    {
        static void Main(string[] args)
        {
            Cancion tiempoNoPara = new Cancion();
            tiempoNoPara.Nombre = "El Tiempo no para";
            creandoDB(tiempoNoPara);
            leyendoDB(tiempoNoPara);
        }

        private static void creandoDB(Cancion tiempoNoPara)
        {
            using (var ado = new AdoMySQLEntity())
            {
                ado.Database.EnsureCreated();
                
                Cancion srCobranza = new Cancion();
                srCobranza.Nombre = "Señor Cobranza";

                Usuario pepito = new Usuario()
                {
                    NombreUsuario = "Pepito",
                    Password = "pepitoPass"
                };

                pepito.reproducirCancion(tiempoNoPara);
                pepito.reproducirCancion(srCobranza);
                System.Threading.Thread.Sleep(3500);
                pepito.reproducirCancion(tiempoNoPara);

                ado.Canciones.Add(tiempoNoPara);
                ado.Canciones.Add(srCobranza);
                ado.Usuarios.Add(pepito);

                ado.SaveChanges();
            }
        }


        private static void leyendoDB(Cancion tiempoNoPara)
        {
            List<Reproduccion> reproducciones;
            using (var ado = new AdoMySQLEntity())
            {
                imprimirReproducciones(ado.getReproducciones());
                reproducciones = ado.getReproducciones(tiempoNoPara);
            }
            Console.Write($"Reproducciones que tiene el tiempo no para: {reproducciones.Count}");
            Console.ReadKey();            
        }

        private static void imprimirReproducciones(List<Reproduccion> list)
        {
            foreach (var repro in list)
            {
                Console.WriteLine($"{repro.IdReproduccion}\t{repro.FechaHora.ToString()}\t{repro.Cancion.Nombre}\t{repro.Usuario.NombreUsuario}");
            }
        }
    }
}