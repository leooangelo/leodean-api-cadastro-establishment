using MS.Establishment.Domain.Base;
using MS.Establishment.Domain.DTO;
using MS.Establishment.Domain.Paging;
using MS.Establishment.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Establishment.Services.Interfaces
{
    public interface IEstablishmentService
    {
        Task ActiveEstablishment(Guid establishmentID, EstablishmentActiveDeactiveViewModel establishmentActiveDeactiveViewModel);
        Task<ResponsePaging<ResponseEstablishmentDTO>> GetAsyncPage(PagingFiltersBase pagingFiltersBase);
        Task<ResponseEstablishmentDTO> GetByIdAsync(Guid establishmentID);
        Task<ResponseEstablishmentDTO> PostAsync(EstablishmentDTO establishmentViewModel);
        Task<ResponseEstablishmentDTO> UpdateEstablishmentAsync(Guid establishmentID, EstablishmentUpdateDTO establishmentDTO);
        Task UpdateEstablishmentEmailAsync(Guid establishmentID, EstablishmentUpdateEmailDTO establishmentDTO);
    }
}
