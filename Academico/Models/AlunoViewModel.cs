namespace Academico.Models
{
    public class AlunoViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string? PasswordHash { get; set; }
        public required string Telefone { get; set; }
        public required string Endereco { get; set; }
        public required string Complemento { get; set; }
        public required string Bairro { get; set; }
        public required string Municipio { get; set; }
        public required string Uf { get; set; }
        public required string Cep { get; set; }


    }

}
