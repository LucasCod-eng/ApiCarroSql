using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Model;
using WebApplication3.Repositorios.Interfaces;

namespace WebApplication3.Repositorios
{
    public class CarroRepositorio : ICarroRepositorio
    {
        private readonly CarrosDBContext _dbContext;

        public CarroRepositorio(CarrosDBContext carrosDBContext)
        {

            _dbContext = carrosDBContext;

        }
        public async Task<Carro> Adicionar(Carro carro)
        {
             await _dbContext.Carros.AddAsync(carro);
             await _dbContext.SaveChangesAsync();
             return carro;
        }

        public async Task<bool> Apagar(int id)
        {
            Carro carroPorId = await BuscarPorId(id);
            if (carroPorId == null)
            {
                throw new Exception($"Carro para o ID:{id}, não foi encontrado no bando de dados");
            }

            _dbContext.Carros.Remove(carroPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Carro> Atualizar(Carro carro, int id)
        {
            Carro carroPorId = await BuscarPorId(id);
            if(carroPorId == null)
            {
                throw new Exception($"Carro para o ID:{id}, não foi encontrado no bando de dados");
            }

            carroPorId.Nome = carro.Nome;
            carroPorId.Descricao = carro.Descricao;
            carroPorId.Status = carro.Status;


            _dbContext.Carros.Update(carroPorId);
           await _dbContext.SaveChangesAsync();

            return carroPorId;
        }

        public async Task<Carro> BuscarPorId(int id)
        {
            return await _dbContext.Carros.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Carro>> BuscarTodosCarro()
        {
            return await _dbContext.Carros.ToListAsync();
        }
    }
}
