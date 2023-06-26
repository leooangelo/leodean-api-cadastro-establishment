using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Establishment.Domain.ViewModel
{
    public class EstablishmentViewModel
    {
        [MaxLength(200, ErrorMessage = "A nome fantasia deveter no máximo 200 caracteres.")]
        public string? FantasyName { get; set; }

        [Required(ErrorMessage = "Razão social não pode ser vazio")]
        [MinLength(2, ErrorMessage = "A Razão social deveter no mínimo 2 caracteres.")]
        [MaxLength(200, ErrorMessage = "A Razão social deveter no máximo 200 caracteres.")]
        public string CorporateName { get; set; }

        [Required(ErrorMessage = "O CNPJ não pode ser vazia.")]
        [MinLength(14, ErrorMessage = "O CNPJ deve ter no mínimo 14 caracteres.")]
        [MaxLength(14, ErrorMessage = "O CNPJ deveter no máximo 14 caracteres.")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Email não pode ser vazio")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                        ErrorMessage = "O email informado não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefone do SAC não pode ser vazio")]
        [MinLength(12, ErrorMessage = "Telefone do SAC deve ter no mínimo 12 caracteres")]
        [MaxLength(15, ErrorMessage = "Telefone do SAC deve ter no máximo 15 caracteres")]
        public string SACPhone { get; set; }

        [MaxLength(15, ErrorMessage = "Telefone do SAC deve ter no máximo 15 caracteres")]
        public string? TelesalesPhone { get; set; }

        public DateTime? OpeningHours { get; set; }

        public DateTime? ClosingHours { get; set; }

    }
}
