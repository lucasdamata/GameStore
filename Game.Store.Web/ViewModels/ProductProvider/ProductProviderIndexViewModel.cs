using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Game.Store.Web.ViewModels.Product
{
    public class ProductProviderIndexViewModel
    {
        public int IdProvider { get; set; }

        [Display(Name = "Nome do Fornecedor")]
        public string ProviderName { get; set; }

        [Display(Name = "Nome do Produto")]
        public string ProductName { get; set; }
    }
}