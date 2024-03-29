﻿using System.ComponentModel.DataAnnotations;

namespace ApiCliente.Modelos.Dto
{
    public class ClienteDto
    {

        public string Identificacion { get; set; }

        [Required]

        public string Nombre { get; set; }

        public string Genero { get; set; }

        public int Edad { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Contraseña { get; set; }

        public string Estado { get; set; }
    }
}
