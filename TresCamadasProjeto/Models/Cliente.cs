namespace Apresentation.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
    }
}
