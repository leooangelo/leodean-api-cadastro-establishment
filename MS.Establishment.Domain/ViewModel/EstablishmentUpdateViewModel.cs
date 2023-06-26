using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Establishment.Domain.ViewModel
{
    public class EstablishmentUpdateViewModel
    {
        [MaxLength(200, ErrorMessage = "A nome fantasia deveter no máximo 200 caracteres.")]
        public string? FantasyName { get; set; }

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
