using System.ComponentModel.DataAnnotations;

namespace ApiCliente.Modelos
{
    public class Cliente : Persona
    {

        public string Contraseña { get; set; }

        public bool Estado { get; set; }
    }
}
