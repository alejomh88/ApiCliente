using ApiCliente.Modelos;
using ApiCliente.Modelos.Dto;
using AutoMapper;

namespace ApiCliente.ClienteMappers
{
    public class CLienteMapper : Profile
    {
        public CLienteMapper()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Cliente, ActualizarClienteDto>().ReverseMap();
        }
    }
}
