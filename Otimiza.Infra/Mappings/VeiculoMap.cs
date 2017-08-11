using Otimiza.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otimiza.Infra.Mappings
{
    public class VeiculoMap : EntityTypeConfiguration<Veiculo>
    {
        public VeiculoMap()
        {
            ToTable("Veiculo");

            HasKey(x => x.Id);

            Property(x => x.Placa).HasMaxLength(9).IsRequired();
            Property(x => x.Proprietario).HasMaxLength(60).IsRequired();

            HasRequired(x => x.TipoVeiculo);

        }
    }
}
