namespace Otimiza.Domain
{
    public class TipoVeiculo
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public override string ToString()
        {
            return this.Titulo;
        }
    }
}