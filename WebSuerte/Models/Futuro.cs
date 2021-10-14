/* FuturoId -> 10 palabras que describen el futuro

Vision -> Descripción de la buena o mala fortuna que le depara el destino

Imagen -> Enlace de imagen relacionada a ese futuro

Realizar la función GET de nombre "Magic" que devuelva aleatoriamente el modelo de un Futuro.  */


using System.ComponentModel.DataAnnotations;

namespace WebSuerte.Models
{
    public class Futuro
    {
        
            [Key]
            public string SUERTE { get; set; }


         [Required]
        public string Nombre { get; set; }


            [Required]
            public string Opcion { get; set; }



            [Url]
            public string Link { get; set; }





        }
    }
