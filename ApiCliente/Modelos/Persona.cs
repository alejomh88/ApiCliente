using System.ComponentModel.DataAnnotations;

namespace ApiCliente.Modelos
{
    public abstract class Persona
    {
        [Key]
        public string Identificacion { get; set; }

        [Required]  
        
        public string Nombre { get; set; }

        public string Genero { get; set; }

        public int Edad { get; set; }
        
        public string Direccion { get; set; }

        public string Telefono { get; set; }

    }
}
