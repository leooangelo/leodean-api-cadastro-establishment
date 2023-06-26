using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Establishment.Domain.DTO
{
    public class EstablishmentUpdateDTO
    {
        public Guid EstablishmentID { get; set; }
        public string? FantasyName { get; set; }

        public string SACPhone { get; set; }

        public string? TelesalesPhone { get; set; }

        public DateTime? OpeningHours { get; set; }

        public DateTime? ClosingHours { get; set; }
    }
}
