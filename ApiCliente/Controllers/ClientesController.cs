using ApiCliente.Modelos;
using ApiCliente.Modelos.Dto;
using ApiCliente.Repositorio.IRepositorio;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiCliente.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepositorio _clRepo;
        private readonly IMapper _mapper;

        public ClientesController(IClienteRepositorio clRepo, IMapper mapper)
        {
            _clRepo = clRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetClientes()
        {
            var listaClientes = _clRepo.GetClientes();

            var listaClientesDto = new List<ClienteDto>();

            foreach (var lista in listaClientes)
            {
                listaClientesDto.Add( _mapper.Map<ClienteDto>(lista));
            }
            return Ok(listaClientesDto);
        }

        [HttpGet("{clienteId:int}", Name = "GetCliente")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCliente(int clienteId)
        {
            var itemCliente = _clRepo.GetCliente(clienteId);

            if (itemCliente == null)
            {
                return NotFound();
            }

            var itemClienteDto = _mapper.Map<ClienteDto>(itemCliente);
            return Ok(itemCliente);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ClienteDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CrearCliente([FromBody] CrearClienteDto crearClienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (crearClienteDto == null)
            {
                return BadRequest(ModelState);
            }
            if (_clRepo.ExisteCliente(crearClienteDto.Identificacion))
            {
                ModelState.AddModelError("", "El cliente ya existe");
                return StatusCode(404, ModelState);
            }

            var cliente = _mapper.Map<Cliente>(crearClienteDto);
            if (!_clRepo.CrearCliente(cliente))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro {cliente.Nombre}");
                return StatusCode(500, ModelState);
            }
            return CreatedAtRoute("GetCliente", new { clienteId = cliente.Id }, cliente);
        }

        [HttpPatch("{clienteId:int}", Name = "ActualizarPatchCliente")]
        [ProducesResponseType(201, Type = typeof(ClienteDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ActualizarPatchCliente(int clienteId, [FromBody] ClienteDto clienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (clienteDto == null || clienteId != clienteDto.Id)
            {
                return BadRequest(ModelState);
            }

            var cliente = _mapper.Map<Cliente>(clienteDto);

            if (!_clRepo.ActualizarCliente(cliente))
            {
                ModelState.AddModelError("", $"Algo salió mal actualizando el registro {cliente.Nombre}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{clienteId:int}", Name = "BorrarCliente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult BorrarCliente(int clienteId)
        {
            if (!_clRepo.ExisteCliente(clienteId))
            {
                return NotFound();
            }

            var cliente = _clRepo.GetCliente(clienteId);

            if (!_clRepo.BorrarCliente(cliente))
            {
                ModelState.AddModelError("", $"Algo salió mal borrando el registro {cliente.Nombre}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
