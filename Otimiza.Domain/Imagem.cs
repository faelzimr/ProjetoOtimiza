﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otimiza.Domain
{
    public class Imagem
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public string Title { get; set; }

        public int VeiculoId { get; set; }

        public virtual Veiculo Veiculo { get; set; }
    }
}
