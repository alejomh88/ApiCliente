using ApiCliente.Modelos;

namespace ApiCliente.Repositorio.IRepositorio
{
    public interface IClienteRepositorio
    {

        Cliente GetClienteIdentificacion(string identificacion);

        ICollection<Cliente> GetClientes();

        bool CrearCliente(Cliente cliente);

        bool ActualizarCliente(Cliente cliente);

        bool BorrarCliente(Cliente cliente);

        bool ExisteCliente(string identificacion);

        bool Guardar();
    }
}
