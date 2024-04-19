using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Model;
using WebApplication3.Repositorios.Interfaces;

namespace WebApplication3.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly CarrosDBContext _dbContext;

        public UsuarioRepositorio(CarrosDBContext carrosDBContext)
        {

            _dbContext = carrosDBContext;

        }
        public async Task<Usuario> Adicionar(Usuario usuario)
        {
             await _dbContext.Usuarios.AddAsync(usuario);
             await _dbContext.SaveChangesAsync();
             return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            Usuario usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID:{id}, não foi encontrado no bando de dados");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Usuario> Atualizar(Usuario usuario, int id)
        {
            Usuario usuarioPorId = await BuscarPorId(id);
            if(usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID:{id}, não foi encontrado no bando de dados");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.email = usuario.email;

            _dbContext.Usuarios.Update(usuarioPorId);
           await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<Usuario> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Usuario>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
    }
}
