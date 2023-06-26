using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MS.Establishment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Establishment.Infra.DataAccess.Mappings
{
    public class EstablishmentMap : IEntityTypeConfiguration<EstablishmentDomain>
    {
        public void Configure(EntityTypeBuilder<EstablishmentDomain> builder)
        {
            builder.HasKey(x => x.EstablishmentID);

            builder.Property(x => x.EstablishmentID)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");

            builder.Property(x => x.FantasyName)
                .HasMaxLength(200)
                .HasColumnType("VARCHAR(200)");

            builder.Property(x => x.CorporateName)
                .HasMaxLength(200)
                .HasColumnType("VARCHAR(200)")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(x => x.CNPJ)
                .HasMaxLength(100)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(x => x.SACPhone)
                .HasMaxLength(30)
                .HasColumnType("VARCHAR(30)")
                .IsRequired();

            builder.Property(x => x.TelesalesPhone)
                .HasMaxLength(30)
                .HasColumnType("VARCHAR(30)");

            builder.Property(x => x.OpeningHours)
                .HasColumnType("datetime");

            builder.Property(x => x.ClosingHours)
                .HasColumnType("datetime");

            builder.Property(x => x.EstablishmentID)
                .HasMaxLength(100)
                .HasColumnType("VARCHAR(100)");

            builder.Property(x => x.IsActive).IsRequired();
        }
    }
}
