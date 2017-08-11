using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otimiza.Domain
{
    public class Veiculo
    {
        public int Id { get; set; }

        public string Placa { get; set; }

        public string Proprietario { get; set; }

        public int TipoVeiculoId { get; set; }

        public virtual TipoVeiculo TipoVeiculo  { get; set; }

        public override string ToString()
        {
            return this.Placa;
        }

    }
}
