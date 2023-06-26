using Microsoft.EntityFrameworkCore;
using MS.Establishment.Domain.Entities;
using MS.Establishment.Infra.DataAccess.Context;
using MS.Establishment.Infra.DataAccess.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Establishment.Infra.DataAccess.Repositories
{
    public class EstablishmentRepository : IEstablishmentRepository
    {
        private EstablishmentContext _establishmentContext;

        public EstablishmentRepository(EstablishmentContext establishmentContext)
        {
            _establishmentContext = establishmentContext;
        }


        public async Task<EstablishmentDomain> GetByIdAsync(Guid establishmentID)
        {
            var establishment = await _establishmentContext.Establishment.FindAsync(establishmentID);
            return establishment;
        }
        public async Task<IList<EstablishmentDomain>> GetAsync()
        {
            var establishment = await _establishmentContext.Establishment.ToListAsync();
            return establishment;
        }

        public async Task<EstablishmentDomain> CreatAsync(EstablishmentDomain establishmentToAdd)
        {
            await _establishmentContext.Establishment.AddAsync(establishmentToAdd);
            await _establishmentContext.SaveChangesAsync();

            return establishmentToAdd;
        }

        public async Task<EstablishmentDomain> GetByCNPJAsync(string cnpj)
        {
            var establishment = await _establishmentContext.Establishment.FirstOrDefaultAsync(x => x.CNPJ == cnpj);
            return establishment;
        }

        public async Task<EstablishmentDomain> UpdateActiveEstablishmentAsync(EstablishmentDomain establishment)
        {
            var entry = _establishmentContext.Entry(establishment);

            entry.State = EntityState.Modified;
            entry.Property(x => x.FantasyName).IsModified = false;
            entry.Property(x => x.CorporateName).IsModified = false;
            entry.Property(x => x.CNPJ).IsModified = false;
            entry.Property(x => x.Email).IsModified = false;
            entry.Property(x => x.SACPhone).IsModified = false;
            entry.Property(x => x.TelesalesPhone).IsModified = false;
            entry.Property(x => x.ClosingHours).IsModified = false;
            entry.Property(x => x.OpeningHours).IsModified = false;
            entry.Property(x => x.AddressID).IsModified = false;

            await _establishmentContext.SaveChangesAsync();
            return establishment;
        }

        public async Task<EstablishmentDomain> UpdateEstablishmentEmailAsync(EstablishmentDomain establishment)
        {
            var entry = _establishmentContext.Entry(establishment);

            entry.State = EntityState.Unchanged;
            entry.Property(x => x.Email).IsModified = true;

            await _establishmentContext.SaveChangesAsync();

            return establishment;
        }

        public async Task<EstablishmentDomain> GetBySACPhoneAnsync(string sacPhone)
        {
            var establishment = await _establishmentContext.Establishment.FirstOrDefaultAsync(x => x.SACPhone == sacPhone);
            return establishment;
        }

        public async Task<EstablishmentDomain> UpdateEstablishmentAsync(EstablishmentDomain establishmentToUpdate)
        {
            var entry = _establishmentContext.Entry(establishmentToUpdate);

            entry.State = EntityState.Modified;
            entry.Property(x => x.CorporateName).IsModified = false;
            entry.Property(x => x.CNPJ).IsModified = false;
            entry.Property(x => x.IsActive).IsModified = false;
            entry.Property(x => x.Email).IsModified = false;


            await _establishmentContext.SaveChangesAsync();

            return establishmentToUpdate;
        }
    }
}
