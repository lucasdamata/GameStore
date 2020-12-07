using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Store.Dados.Entity.Context;
using Game.Store.Dominio;
using Game.Store.Repositorios.Common.Entity;
using System.Data.Entity;

namespace Universidade.Cursos.Repositorios.Entity
{
    public class ProductProviderRepositorio : RepositorioGenericoEntity<ProductProvider, int>
    {
        public ProductProviderRepositorio(ProductDbContext contexto)
          : base(contexto)
        {

        }

        public override List<ProductProvider> Selecionar()
        {
            return _contexto.Set<ProductProvider>().Include(p => p.Product).ToList();
        }

        public override ProductProvider SelecionarPorId(int id)
        {
            return _contexto.Set<ProductProvider>().Include(p => p.Product)
                .SingleOrDefault(f => f.IdProvider == id);
        }
    }
}
