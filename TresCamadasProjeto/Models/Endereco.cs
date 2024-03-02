namespace Apresentation.Models
{
    public class Endereco
    {
        public int Id { get; set; } 
        public int ClienteId { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        
    }
}