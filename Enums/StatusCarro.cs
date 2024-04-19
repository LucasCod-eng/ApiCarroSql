using System.ComponentModel;

namespace WebApplication3.Enums
{
    public enum StatusCarro
    {
        [Description("Emprestado")]
        Emprestado = 1,
        [Description("Alugado")]
        Alugado = 2,
        [Description("Proprio")]
        Proprio = 3
        
    }
}
