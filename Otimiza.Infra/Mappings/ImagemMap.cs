﻿using Otimiza.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otimiza.Infra.Mappings
{
    public class ImagemMap : EntityTypeConfiguration<Imagem>
    {
        public ImagemMap()
        {
            ToTable("Imagem");

            HasKey(x=>x.Id);

            Property(x => x.FileName).IsRequired();
            Property(x => x.Title).IsRequired();

            HasRequired(x => x.Veiculo);
        }

    }
}
