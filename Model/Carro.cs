using WebApplication3.Enums;

namespace WebApplication3.Model
{
    public class Carro
    {
        public int Id { get; set; } 
        public string? Nome{ get; set; }    
        public string? Descricao { get; set; }
        public StatusCarro Status { get; set; }
    }
}
