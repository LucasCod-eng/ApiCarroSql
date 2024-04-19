using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Model;
using WebApplication3.Repositorios.Interfaces;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly ICarroRepositorio _carroRepositorio;

        public CarroController(ICarroRepositorio carroRepositorio)
        {
            _carroRepositorio = carroRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Carro>>> BuscarTodosCarros()
        {
            List<Carro> carros = await _carroRepositorio.BuscarTodosCarro();
            return Ok(carros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Carro>> BuscaPorId(int id)
        {
            Carro carro = await _carroRepositorio.BuscarPorId(id);
            return Ok(carro);
         }

        [HttpPost]
        public async Task<ActionResult<Carro>> Cadastrar([FromBody] Carro carro)
        {
            Carro carros = await _carroRepositorio.Adicionar(carro);
            return Ok(carros);
        }

        [HttpPut("id")]
        public async Task<ActionResult<Carro>> Atualizar([FromBody] Carro carro, int id)
        {
            carro.Id = id;
            Carro carros = await _carroRepositorio.Atualizar(carro, id);
            return Ok(carros);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<Carro>> Apagar(int id)
        {
            bool apagado = await _carroRepositorio.Apagar(id);
            return Ok(apagado);
        }

    }
}
