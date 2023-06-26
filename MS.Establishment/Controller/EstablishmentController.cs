using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MS.Establishment.Controllers.Base;
using MS.Establishment.Domain.Base;
using MS.Establishment.Domain.DTO;
using MS.Establishment.Domain.ViewModel;
using MS.Establishment.Services.Interfaces;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MS.Establishment.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstablishmentController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IEstablishmentService _establishmentService;

        public EstablishmentController(IMapper mapper, IEstablishmentService establishmentService, ILogger<BaseController> log, IHttpContextAccessor httpContextAccessor) : base(log, httpContextAccessor)
        {
            _mapper = mapper;
            _establishmentService = establishmentService;
        }


        [HttpGet("{establishmentID}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid establishmentID)
        {
            return CustomResponse(await _establishmentService.GetByIdAsync(establishmentID));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsyncPage([FromQuery] PagingFiltersBase pagingFiltersBase)
        {
            return CustomResponse(await _establishmentService.GetAsyncPage(pagingFiltersBase));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] EstablishmentViewModel establishmentViewModel)
        {
            var establishmentDTO = _mapper.Map<EstablishmentDTO>(establishmentViewModel);
            var establishment = await _establishmentService.PostAsync(establishmentDTO);
            return Ok(new ResultViewModel("Estabelecimento criado com sucesso!", establishment));
        }

        [HttpPost("{establishmentID}/active_deactivate")]
        public async Task<IActionResult> ActiveEstablishment([FromRoute] Guid establishmentID, EstablishmentActiveDeactiveViewModel establishmentActiveDeactiveViewModel)
        {
            await _establishmentService.ActiveEstablishment(establishmentID, establishmentActiveDeactiveViewModel);
            var messageResponse = establishmentActiveDeactiveViewModel.IsActive.Equals(true) ? "Usuário ativado com sucesso!" : "Usuário desativado com sucesso!";
            return Ok(new ResultViewModel(messageResponse));
        }

        [HttpPut("{establishmentID}")]
        public async Task<IActionResult> UpdateEstablishmentAsync ([FromRoute] Guid establishmentID, [FromBody] EstablishmentUpdateViewModel establishmentUpdateViewModel)
        {
            var establishmentDTO = _mapper.Map<EstablishmentUpdateDTO>(establishmentUpdateViewModel);
            await _establishmentService.UpdateEstablishmentAsync(establishmentID, establishmentDTO);
            return Ok(new ResultViewModel("Estabelecimento atualizado com sucesso!"));
        }


        [HttpPut("{establishmentID}/establishment_email")]
        public async Task<IActionResult> UpdateEstablishmentEmailAsync([FromRoute] Guid establishmentID, [FromBody] EstablishmentUpdateEmailViewModel establishmentUpdateEmailViewModel)
        {
            var establishmentDTO = _mapper.Map<EstablishmentUpdateEmailDTO>(establishmentUpdateEmailViewModel);
            await _establishmentService.UpdateEstablishmentEmailAsync(establishmentID, establishmentDTO);
            return Ok(new ResultViewModel("E-mail alterado com sucesso!"));
        }

        // rota para associar endereço a um estabelecimento na base de establishment.

    }
}
