using System.ComponentModel.DataAnnotations;

namespace ApiAtalho.Models
{
    public class ClienteModels
    {
        public int Id { get; set; } 
        public string Nome { get; set; }
        public string Url { get; set; }

        [Required(ErrorMessage="campo obrigatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage="campo obrigatorio")]
        public string Senha { get; set; }

        
    }
}
