using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Game.Store.Web.ViewModels.Product
{
    public class ProductProviderViewModel
    {
        [Required(ErrorMessage = "O ID é obrigatório!")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome do Fornecedor é obrigatório!")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres!")]
        [Display(Name = "Nome do produto")]
        public string ProviderName { get; set; }

        [Required(ErrorMessage = "Selecione um produto!")]
        [MaxLength(1000, ErrorMessage = "A descrição deve ter no máximo 1000 caracteres")]
        [Display(Name = "Nome do Produto")]
        public int IdProduct { get; set; }
    }
}