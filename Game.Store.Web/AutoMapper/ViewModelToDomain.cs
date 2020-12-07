using AutoMapper;
using Game.Store.Dominio;
using Game.Store.Web.ViewModels.Product;
using Game.Store.Web.ViewModels.ProductProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Game.Store.Web.AutoMapper
{
    public class ViewModelToDomain : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ProductViewModel, Product>();
            Mapper.CreateMap<ProductProviderViewModel, ProductProvider>();
        }
    }
}