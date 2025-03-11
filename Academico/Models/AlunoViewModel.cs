using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class AlunoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Informe um email válido.")]
        public required string Email { get; set; }

        //[Required(ErrorMessage = "A senha é obrigatória.")]
        //[MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
        public required string? PasswordHash { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [RegularExpression(@"^\(?\d{2}\)?[\s-]?\d{4,5}-?\d{4}$", ErrorMessage = "Informe um telefone válido (ex: (11) 91234-5678).")]
        public required string Telefone { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório.")]
        public required string Endereco { get; set; }

        public string? Complemento { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório.")]
        public required string Bairro { get; set; }

        [Required(ErrorMessage = "O município é obrigatório.")]
        public required string Municipio { get; set; }

        [Required(ErrorMessage = "O UF é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O UF deve ter exatamente 2 caracteres.")]
        public required string Uf { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [RegularExpression(@"^\d{5}-?\d{3}$", ErrorMessage = "Informe um CEP válido (ex: 12345-678).")]
        public required string Cep { get; set; }
    }

}
