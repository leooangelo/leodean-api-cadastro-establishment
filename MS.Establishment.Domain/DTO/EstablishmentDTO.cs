using MS.Establishment.Domain.DTO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Establishment.Domain.DTO
{
    public class EstablishmentDTO : BaseDTO
    {
        public Guid EstablishmentID { get; set; }

        public string? FantasyName { get; set; }

        public string CorporateName { get; set; }

        public string CNPJ { get; set; }

        public string Email { get; set; }

        public string SACPhone { get; set; }

        public string? TelesalesPhone { get; set; }

        public DateTime? OpeningHours { get; set; }

        public DateTime? ClosingHours { get; set; }

        public string? AddressID { get; private set; }

        public bool IsActive { get; set; }
    }
}
