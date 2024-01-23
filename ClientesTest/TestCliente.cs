using ApiCliente.Controllers;
using ApiCliente.Modelos;
using ApiCliente.Repositorio;
using ApiCliente.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ClientesTest
{
    public class TestCliente : BaseContextPrueba
    {

        [Test]
        public async Task ObtenerCliente()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("ConexionSql");
            string NombreBD = connectionString;
            var context = ConstruirContext(NombreBD);


            context.Cliente.Add(
                new Cliente()
                {
                    Nombre = "Pedro",
                    Genero = "M",
                    Edad = 30,
                    Identificacion = "0723456789",
                    Direccion = "abc",
                    Telefono = "123123",
                    Contraseña = "4321",
                    Estado = true
                });
            await context.SaveChangesAsync();

            var context2 = ConstruirContext(NombreBD);
            var controller = new ClienteRepositorio(context2);

            var resp = controller.GetClientes();

            Assert.IsNotNull(resp);

        }

        [Test]
        public void EjecutarCliente()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("ConexionSql");
            string NombreBD = connectionString;
            var context = ConstruirContext(NombreBD);

            ClienteRepositorio rspObject = new ClienteRepositorio(context);
            var rsp = rspObject.GetClientes().ToList();

            Assert.IsNotNull(rsp);
        }

    }
}
