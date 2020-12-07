using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Store.Dados.Generica.Entity
{
    public abstract class LojaEntityAbstractConfig<TEntidade> : EntityTypeConfiguration<TEntidade>
        where TEntidade : class
    {
        public LojaEntityAbstractConfig()
        {
            ConfigurarNomeTabela();
            ConfigurarCamposTabela();
            ConfigurarChavePrimaria();
            ConfigurarChaveEstrangeira();
        }

        protected abstract void ConfigurarNomeTabela();

        protected abstract void ConfigurarCamposTabela();

        protected abstract void ConfigurarChavePrimaria();

        protected abstract void ConfigurarChaveEstrangeira();
    }
}
