using ApiCliente.Data;
using ApiCliente.Modelos;
using ApiCliente.Repositorio.IRepositorio;

namespace ApiCliente.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly ApplicationDbContext _bd;

        public ClienteRepositorio(ApplicationDbContext db)
        {
                _bd = db;
        }

        public bool ActualizarCliente(Cliente cliente)
        {
            _bd.Cliente.Update(cliente);
            return Guardar();
        }

        public bool CrearCliente(Cliente cliente)
        {
            _bd.Cliente.Add(cliente);
            return Guardar();
        }

        public bool BorrarCliente(Cliente cliente)
        {
            _bd.Cliente.Remove(cliente);
            return Guardar();
        }

        public ICollection<Cliente> GetClientes()
        {
            return _bd.Cliente.OrderBy(c => c.Nombre).ToList();
        }

        public bool ExisteCliente(string identificacion)
        {
            bool valor = _bd.Cliente.Any(c => c.Identificacion.ToLower().Trim() == identificacion.ToLower().Trim());
            return valor;
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }

        public Cliente GetClienteIdentificacion(string identificacion)
        {
            return _bd.Cliente.FirstOrDefault(c => c.Identificacion == identificacion);
        }
    }
}
