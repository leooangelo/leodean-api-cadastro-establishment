using AutoMapper;
using MS.Establishment.Domain.Base;
using MS.Establishment.Domain.DTO;
using MS.Establishment.Domain.Entities;
using MS.Establishment.Domain.Paging;
using MS.Establishment.Domain.ViewModel;
using MS.Establishment.Infra.DataAccess.Repositories.interfaces;
using MS.Establishment.Services.Interfaces;
using MS.Establishment.Utils.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace MS.Establishment.Services
{
    public class EstablishmentService : IEstablishmentService
    {
        private readonly IMapper _mapper;
        private readonly IEstablishmentRepository _establishmentRepository;
        private readonly IValidator _validator;

        public EstablishmentService(IMapper mapper, IEstablishmentRepository establishmentRepository, IValidator validator)
        {
            _mapper = mapper;
            _establishmentRepository = establishmentRepository;
            _validator = validator;
        }

        public async Task<ResponseEstablishmentDTO> GetByIdAsync(Guid establishmentID)
        {
            var establishment = await _establishmentRepository.GetByIdAsync(establishmentID);
            return _mapper.Map<ResponseEstablishmentDTO>(establishment);
        }

        public async Task<ResponsePaging<ResponseEstablishmentDTO>> GetAsyncPage(PagingFiltersBase pagingFiltersBase)
        {
            var establishmentBase = await _establishmentRepository.GetAsync();
            var establishmentQuery = _mapper.Map<IList<ResponseEstablishmentDTO>>(establishmentBase).ToList().AsQueryable();

            var establishmentResponse = (from e in establishmentQuery.ToList() select e).ToList();

            if (pagingFiltersBase.page > 0 && pagingFiltersBase.page_size > 0)
            {
                var page = PagingUtils.Paging(establishmentResponse.AsQueryable(), pagingFiltersBase.page, pagingFiltersBase.page_size);

                ResponsePaging<ResponseEstablishmentDTO> responsePaging = new ResponsePaging<ResponseEstablishmentDTO>();
                responsePaging.pagination = new PagingModel()
                {
                    page_count = page.pagination.page_count,
                    page_size = page.pagination.page_size,
                    current_page = page.pagination.current_page,
                    row_count = page.pagination.row_count
                };

                responsePaging.data = page.data;
                return responsePaging;
            }

            return new ResponsePaging<ResponseEstablishmentDTO>()
            {
                data = establishmentResponse
            };
        }

        public async Task<ResponseEstablishmentDTO> PostAsync(EstablishmentDTO establishmentViewModel)
        {
            var establishmentToAdd = _mapper.Map<EstablishmentDomain>(establishmentViewModel);

            establishmentValid(establishmentToAdd.CNPJ);
            establishmentToAddExist(establishmentToAdd.CNPJ, establishmentViewModel.Email);
            establishmentToAdd.HashDocument();
            var establishment = await _establishmentRepository.CreatAsync(establishmentToAdd);
            var responseEstablishment = _mapper.Map<ResponseEstablishmentDTO>(establishment);

            return responseEstablishment;
        }

        public async Task ActiveEstablishment(Guid establishmentID, EstablishmentActiveDeactiveViewModel establishmentActiveDeactiveViewModel)
        {
            var establishment = await _establishmentRepository.GetByIdAsync(establishmentID);

            //Validar na api se o endereço existe
            if (establishment.AddressID == null)
                throw new Exception("Erro, estabelecimento não tem endereço cadastrado!");

            establishment.IsActive = establishmentActiveDeactiveViewModel.IsActive;

            await _establishmentRepository.UpdateActiveEstablishmentAsync(establishment);
        }

        public async Task<ResponseEstablishmentDTO> UpdateEstablishmentAsync(Guid establishmentID, EstablishmentUpdateDTO establishmentDTO)
        {
            var establishmentPhoneUpdateExistResponse = establishmentPhoneUpdateExist(establishmentDTO.SACPhone, establishmentID);

            if (establishmentPhoneUpdateExistResponse == true)
                throw new Exception("Erro, telefone ou celular ja cadastrado");

            var establishmentToUpdate = _mapper.Map<EstablishmentDomain>(establishmentDTO);
            establishmentToUpdate.EstablishmentID = establishmentID;

            var establishment = await _establishmentRepository.UpdateEstablishmentAsync(establishmentToUpdate);
            return _mapper.Map<ResponseEstablishmentDTO>(establishment);

        }

        public async Task UpdateEstablishmentEmailAsync(Guid establishmentID, EstablishmentUpdateEmailDTO establishmentDTO)
        {
            establishmentValid(establishmentDTO.CNPJ);
            var establishment = await _establishmentRepository.GetByIdAsync(establishmentID);

            if (establishment == null)
                throw new Exception("Erro, estabelecimento não existe!");

            if (!BC.Verify(establishmentDTO.CNPJ, establishment.CNPJ))
                throw new Exception("Erro, CNPJ informado não é compatível com o CNPJ de cadastro!");

            if (!establishmentDTO.NewEmailConfirmed.Equals(establishmentDTO.NewEmail))
                throw new Exception("Erro, e-mail informado não é compativel com a confirmação de e-mail!");

            if (establishmentDTO.NewEmailConfirmed.Equals(establishment.Email))
                throw new Exception("Erro, novo e-mail não pode ser igual ao e-mail atual!");

            establishment.SetEmail(establishmentDTO.NewEmailConfirmed);

            await _establishmentRepository.UpdateEstablishmentEmailAsync(establishment);
        }


        private void establishmentValid(string CNPJ)
        {
           var cnpjValid =  _validator.IsCnpj(CNPJ);

            if(cnpjValid == false)
             throw new Exception("Erro, CNPJ inválido!");
        }

        private void establishmentToAddExist(string CNPJ, string email)
        {
            var establishments = _establishmentRepository.GetAsync().Result;

            foreach(var e in establishments)
            {

                if (BC.Verify(CNPJ, e.CNPJ))
                    throw new Exception("Erro, CNPJ ja cadastrado.");

                if (e.Email.Equals(email))
                    throw new Exception("Erro, E-mail ja cadastrado.");
            }
        }

        private Boolean establishmentPhoneUpdateExist(string sacPhone, Guid establishmentID)
        {
            EstablishmentDomain res = GetBySACPhoneAnsync(sacPhone).Result;

            if (res == null)
                return false;

            if (establishmentID == res.EstablishmentID)
                return false;

            return true;
        }

        private async Task<EstablishmentDomain> GetBySACPhoneAnsync(string sacPhone)
        {
            var customer = await _establishmentRepository.GetBySACPhoneAnsync(sacPhone);
            return customer;
        }
    }
}
