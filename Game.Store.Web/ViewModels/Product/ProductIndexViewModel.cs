using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Game.Store.Web.ViewModels.Product
{
    public class ProductIndexViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome do produto")]
        public string Name { get; set; }

        [Display(Name = "Descrição do produto")]
        public string Description { get; set; }

        [Display(Name = "Preço do produto")]
        public float Price { get; set; }

        [Display(Name = "Quantidade em estoque")]
        public int QuantityInStock { get; set; }
    }
}