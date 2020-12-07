using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Store.Dominio
{
    public class ProductProvider
    {
        public int IdProvider { get; set; }
        public string ProviderName { get; set; }
        public virtual Product Product { get; set; }
        public int IdProduct { get;  set; }
    }
}
