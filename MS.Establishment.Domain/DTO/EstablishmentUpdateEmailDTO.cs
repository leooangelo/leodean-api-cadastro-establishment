using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Establishment.Domain.DTO
{
    public class EstablishmentUpdateEmailDTO
    {
        public string CNPJ { get; set; }

        public string NewEmail { get; set; }

        public string NewEmailConfirmed { get; set; }
    }
}
