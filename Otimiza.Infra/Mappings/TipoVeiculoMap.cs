using Otimiza.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otimiza.Infra.Mappings
{
    public class TipoVeiculoMap : EntityTypeConfiguration<TipoVeiculo>
    {
        public TipoVeiculoMap()
        {
            ToTable("TipoVeiculo");
            HasKey(x => x.Id);

            Property(x => x.Titulo).HasMaxLength(50).IsRequired();
        }
    }
}
