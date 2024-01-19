using ApiCliente.Data;
using ApiCliente.Modelos;
using ApiCliente.Modelos.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesTest
{
    public class BaseContextPrueba
    {
        protected ApiCliente.Data.ApplicationDbContext ConstruirContext(string ConexionSQL)
        {
            var option = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(ConexionSQL).Options;

            var dBContext = new ApplicationDbContext(option);
            return dBContext;

        }
        
    }
}
