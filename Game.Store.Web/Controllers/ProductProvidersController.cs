using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Game.Store.Dados.Entity.Context;
using Game.Store.Dominio;
using Game.Store.Repositorios.Common;
using Game.Store.Repositorios.Entity;
using Game.Store.Web.ViewModels.ProductProvider;
using Game.Store.Web.ViewModels.Product;

namespace Game.Store.Web.Controllers
{
    [Authorize]
    public class ProductProviderController : Controller
    {
        private IRepositorioGenerico<ProductProvider, int>
            repositorioProductProvider = new ProductProviderRepositorio(new ProductDbContext());

        private IRepositorioGenerico<Product, int>
            repositorioProduct = new ProductRepositorio(new ProductDbContext());

        // GET: ProductProviders
        public ActionResult Index()
        {
            return View(Mapper.Map<List<ProductProvider>,
               List<ProductProviderIndexViewModel>>(repositorioProductProvider.Selecionar()));
        }

        // GET: ProductProviders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductProvider productProvider = repositorioProductProvider.SelecionarPorId(id.Value);
            if (productProvider == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<ProductProvider, ProductProviderIndexViewModel>(productProvider));
        }

        // GET: ProductProvider/Create
        public ActionResult Create()
        {
            List<ProductIndexViewModel> products = Mapper.Map<List<Product>,
               List<ProductIndexViewModel>>(repositorioProduct.Selecionar());


            SelectList dropDownProducts = new SelectList(products, "Id", "Name");
            ViewBag.DropDownProducts = dropDownProducts;
            return View();
        }

        // POST: productProvider/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProvider,ProviderName,IdProduct")] ProductProviderViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ProductProvider productProvider = Mapper.Map<ProductProviderViewModel, ProductProvider>(viewModel);
                repositorioProductProvider.Inserir(productProvider);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: productProvider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductProvider productProvider = repositorioProductProvider.SelecionarPorId(id.Value);
            if (productProvider == null)
            {
                return HttpNotFound();
            }

            List<ProductIndexViewModel> products = Mapper.Map<List<Product>,
               List<ProductIndexViewModel>>(repositorioProduct.Selecionar());


            SelectList dropDownProducts = new SelectList(products, "Id", "Nome");
            ViewBag.DropDownDisciplinas = dropDownProducts;
            return View(Mapper.Map<ProductProvider, ProductProviderViewModel>(productProvider));
        }

        // POST: productProvider/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProvider,ProviderName,IdProduct")] ProductProviderViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ProductProvider productProvider = Mapper.Map<ProductProviderViewModel, ProductProvider>(viewModel);
                repositorioProductProvider.Alterar(productProvider);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: productProvider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductProvider productProvider = repositorioProductProvider.SelecionarPorId(id.Value);
            if (productProvider == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<ProductProvider, ProductProviderIndexViewModel>(productProvider));
        }

        // POST: productProvider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            repositorioProductProvider.ExcluirPorId(id);
            return RedirectToAction("Index");
        }
    }
}
