using WebApplication3.Model;

namespace WebApplication3.Repositorios.Interfaces
{
    public interface ICarroRepositorio
    {

        Task<List<Carro>> BuscarTodosCarro();
        Task<Carro> BuscarPorId( int id);

        Task<Carro> Adicionar(Carro carro);

        Task<Carro> Atualizar(Carro carro, int id);
        
        Task<bool> Apagar(int id);
    }
}
