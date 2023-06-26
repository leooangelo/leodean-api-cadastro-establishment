using MS.Establishment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Establishment.Infra.DataAccess.Repositories.interfaces
{
    public interface IEstablishmentRepository
    {
        Task<EstablishmentDomain> CreatAsync(EstablishmentDomain establishmentToAdd);
        Task<IList<EstablishmentDomain>> GetAsync();
        Task<EstablishmentDomain> GetByCNPJAsync(string cnpj);
        Task<EstablishmentDomain> GetByIdAsync(Guid establishmentID);
        Task<EstablishmentDomain> GetBySACPhoneAnsync(string sacPhone);
        Task<EstablishmentDomain> UpdateActiveEstablishmentAsync(EstablishmentDomain establishment);
        Task<EstablishmentDomain> UpdateEstablishmentAsync(EstablishmentDomain establishmentToUpdate);
        Task<EstablishmentDomain> UpdateEstablishmentEmailAsync(EstablishmentDomain establishment);
    }
}
