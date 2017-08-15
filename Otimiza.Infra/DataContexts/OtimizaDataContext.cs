using Otimiza.Domain;
using Otimiza.Infra.Mappings;
using System.Data.Entity;

namespace Otimiza.Infra.DataContexts
{
    public class OtimizaDataContext : DbContext
    {
        public OtimizaDataContext()
            : base("OtimizaConexaoString")
        {
            Database.SetInitializer<OtimizaDataContext>(new OtimizaDataContextInicializa());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Veiculo> Veiculos { get; set; }

        public DbSet<TipoVeiculo> TipoVeiculos { get; set; }

        public DbSet<Imagem> Imagens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VeiculoMap());
            modelBuilder.Configurations.Add(new TipoVeiculoMap());
            modelBuilder.Configurations.Add(new ImagemMap());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class OtimizaDataContextInicializa : DropCreateDatabaseIfModelChanges<OtimizaDataContext>
    {
        protected override void Seed(OtimizaDataContext context)
        {
            context.TipoVeiculos.Add(new TipoVeiculo { Id = 1, Titulo = "Motocicleta" });
            context.TipoVeiculos.Add(new TipoVeiculo { Id = 2, Titulo = "Automóvel" });
            context.TipoVeiculos.Add(new TipoVeiculo { Id = 3, Titulo = "Microônibus" });
            context.TipoVeiculos.Add(new TipoVeiculo { Id = 4, Titulo = "Ônibus" });
            context.TipoVeiculos.Add(new TipoVeiculo { Id = 5, Titulo = "Caminhão" });
            context.TipoVeiculos.Add(new TipoVeiculo { Id = 6, Titulo = "Caminhão-Trator" });
            context.TipoVeiculos.Add(new TipoVeiculo { Id = 7, Titulo = "Caminhonete" });
            context.SaveChanges();

            context.Veiculos.Add(new Veiculo { Id = 1, Placa = "hhv-1723", TipoVeiculoId = 1, Proprietario = "Rafael" });
            context.Veiculos.Add(new Veiculo { Id = 2, Placa = "gfh-1289", TipoVeiculoId = 2, Proprietario = "Roger" });
            context.Veiculos.Add(new Veiculo { Id = 2, Placa = "fgd-2345", TipoVeiculoId = 3, Proprietario = "Roberto" });
            context.Veiculos.Add(new Veiculo { Id = 2, Placa = "dfg-5465", TipoVeiculoId = 4, Proprietario = "Rafael" });
            context.Veiculos.Add(new Veiculo { Id = 2, Placa = "vcb-5676", TipoVeiculoId = 5, Proprietario = "Rômulo" });
            context.Veiculos.Add(new Veiculo { Id = 2, Placa = "cvb-4454", TipoVeiculoId = 6, Proprietario = "Roberta" });
            context.Veiculos.Add(new Veiculo { Id = 2, Placa = "ghf-5467", TipoVeiculoId = 7, Proprietario = "Ricardo" });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
