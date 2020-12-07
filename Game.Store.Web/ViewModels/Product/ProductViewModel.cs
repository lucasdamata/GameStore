using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Game.Store.Web.ViewModels.Product
{
    public class ProductViewModel
    {
        [Required(ErrorMessage = "O ID é obrigatório, seu corno!")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório, hdp!")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres, poha!")]
        [Display(Name = "Nome do produto")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória, carajo!")]
        [MaxLength(1000, ErrorMessage = "A descrição só pode ter 1000 caracteres")]
        [Display(Name = "Descrição do produto")]
        public string Description { get; set; }

        [Display(Name = "Preço do produto")]
        [Required(ErrorMessage = "Preço é obrigatório")]
        public float Price { get; set; }

        [Display(Name = "Quantidade em estoque")]
        public int QuantityInStock { get; set; }
    }
}