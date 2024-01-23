using ApiCliente.Modelos;
using ApiCliente.Modelos.Dto;
using AutoMapper;

namespace ApiPrueba.ClienteMappers
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
