
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace MS.Establishment.Domain.Entities
{
    public class EstablishmentDomain : BaseEntity
    {
        public EstablishmentDomain()
        {
        }

        public Guid EstablishmentID { get; set; }

        public string? FantasyName { get; set; }

        public  string CorporateName { get; set; }

        public string CNPJ { get; set; }

        public string Email { get; set; }

        public string SACPhone { get; set; }

        public string? TelesalesPhone { get; set; }

        public DateTime? OpeningHours { get; set; }

        public DateTime? ClosingHours { get; set; }

        public string? AddressID { get; set; }

        public bool IsActive { get; set; }

        public void HashDocument()
        {
            CNPJ = BC.HashPassword(CNPJ);
        }

        public void SetCNPJ(string CNPJ)
        {
            CNPJ = BC.HashPassword(CNPJ);
        }

        public void SetEmail(string newEmail)
        {
            Email = newEmail;
        }
    }
}
