using Loja.Eletronicos.Dados.Generica.Entity;
using Loja.Eletronicos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Eletronicos.Dados.Entity.TypeConfiguration
{
    class ProductTypeConfiguration : LojaEntityAbstractConfig<Product>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("Id");

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Name");

            Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(1000)
                .HasColumnName("Description");

            Property(p => p.Price)
                .IsRequired()
                .HasColumnName("Price");

            Property(p => p.QuantityInStock)
                .IsOptional()
                .HasColumnName("QuantityInStock");

        }

        protected override void ConfigurarChaveEstrangeira()
        {
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("Products");
        }
    }
}
