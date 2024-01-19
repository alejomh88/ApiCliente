using ApiCliente.Modelos;

namespace ApiCliente.Repositorio.IRepositorio
{
    public interface IClienteRepositorio
    {
        ICollection<Cliente> GetCliente();

        Cliente GetCliente(int id);

        ICollection<Cliente> GetClientes();

        bool CrearCliente(Cliente cliente);

        bool ActualizarCliente(Cliente cliente);

        bool BorrarCliente(Cliente cliente);

        bool ExisteCliente(string identificacion);
        
        bool ExisteCliente(int id);

        bool Guardar();
    }
}
