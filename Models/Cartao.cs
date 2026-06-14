using System.ComponentModel.DataAnnotations;

namespace GerenciadorCartoes.Models
{
    public class Cartao
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome impresso no cartão é obrigatório.")]
        [Display(Name = "Nome no Cartão")]
        public string NomeTitular { get; set; } = string.Empty;

        [Required(ErrorMessage = "O número do cartão é obrigatório.")]
        [CreditCard(ErrorMessage = "Número de cartão inválido.")] // Validação nativa do .NET
        [Display(Name = "Número do Cartão")]
        public string NumeroCartao { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de validade é obrigatória.")]
        [Display(Name = "Validade (MM/AA)")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$", ErrorMessage = "Formato inválido. Use MM/AA.")]
        public string DataValidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CVV é obrigatório.")]
        [StringLength(4, MinimumLength = 3, ErrorMessage = "O CVV deve ter 3 ou 4 dígitos.")]
        [Display(Name = "Código de Segurança (CVV)")]
        public string Cvv { get; set; } = string.Empty;

        // Propriedade calculada (Não vai para o banco, serve para o portfólio!)
        public string NumeroMascarado => string.IsNullOrEmpty(NumeroCartao) 
            ? "" 
            : $"**** **** **** {NumeroCartao.Substring(NumeroCartao.Length - 4)}";

        public string Bandeira => ObterBandeira();

        private string ObterBandeira()
        {
            if (string.IsNullOrEmpty(NumeroCartao)) return "Desconhecida";
            if (NumeroCartao.StartsWith("4")) return "Visa";
            if (NumeroCartao.StartsWith("5")) return "Mastercard";
            if (NumeroCartao.StartsWith("3")) return "American Express";
            return "Outra";
        }
    }
}