using ApiAtalho.Models;

namespace ApiAtalho.Interface
{
    public interface IClienteService
    {
        
        bool Cadastrar(ClienteModels cliente);
        bool Deletar( int Id);
        List<ClienteModels>? BuscarTodos();
    }
}
