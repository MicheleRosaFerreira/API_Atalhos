using ApiAtalho.Interface;
using ApiAtalho.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ApiAtalho.Controllers
{
    [ApiController]


    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
    

        [HttpGet]
        [Route("/api/v1/clientes")]

        public ActionResult<ClienteModels> BuscarTodosClientes()
        {
            try
            {
                var clientes = _clienteService.BuscarTodos();
                if (clientes != null && clientes.Count > 0)

                    return Ok(clientes);

                else 
                    
                    return BadRequest("nenhum cliente encontrado");
            }
            catch
            {
                return BadRequest("nenhum cliente encontrado");
            }
        }

    
          [HttpPost]
          [Route("/api/v1/clientes")]
           public ActionResult<ClienteModels> Cadastrar([FromBody] ClienteModels cliente)

           {
            try
            {
                if (_clienteService.Cadastrar(cliente) == true)
                {
                    return CreatedAtAction(null, "cliente cadastrado com sucesso");

                }
               
                    return Ok("Cliente cadastrado com sucesso!");

                }
                catch
                {
                return BadRequest("Erro ao Cadastrar cliente!");
            }

            }
            [HttpDelete]
            [Route("/api/v1/deletar/clientes{id}")]

            public ActionResult<ClienteModels> Deletar(int id)
            {

               
                if (_clienteService.Deletar (id) == true)
                {
                return Ok("Cliente deletado com sucesso");
            }
            else
            {
                return BadRequest("Erro ao deletar cliente");
            }
            }
        }

    }
