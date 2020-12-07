using Loja.Eletronicos.Dados.Generica.Entity;
using Loja.Eletronicos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Eletronicos.Dados.Entity.TypeConfiguration
{
    class ProductProviderTypeConfiguration : LojaEntityAbstractConfig<ProductProvider>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.IdProvider)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(p => p.ProviderName)
                .HasColumnName("ProviderName")
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.IdProduct)
                .HasColumnName("IdProduct")
                .IsRequired();
        }

        protected override void ConfigurarChaveEstrangeira()
        {
            HasRequired(p => p.Product)
                .WithMany(p => p.Providers)
                .HasForeignKey(fk => fk.IdProduct);
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.IdProvider);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("ProductProvider");
        }
    }
}
