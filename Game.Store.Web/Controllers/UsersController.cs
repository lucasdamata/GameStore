using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Game.Store.Dados.Entity.Context;
using Game.Store.Web.Identity;
using Game.Store.Web.ViewModels.Users;

namespace Game.Store.Web.Controllers
{
    public class UsersController : Controller
    {
        [AllowAnonymous]
        public class UsersController : Controller
        {
            // GET: Usuarios
            [AllowAnonymous]
            public ActionResult CriarUsuario()
            {
                return View();
            }

            // POST: Usuarios
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult CriarUsuario(UsuarioViewModel viewModel)
            {
                if (ModelState.IsValid)
                {
                    var userStore = new UserStore<IdentityUser>(new ProductIdentityDbContext());
                    var userManager = new UserManager<IdentityUser>(userStore);
                    var identityUser = new IdentityUser
                    {
                        UserName = viewModel.Email,
                        Email = viewModel.Email
                    };
                    IdentityResult resultado = userManager.Create(identityUser, viewModel.Senha);

                    if (resultado.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("erro_identity", resultado.Errors.First());
                        return View(viewModel);
                    }
                }
                return View(viewModel);
            }

            public ActionResult Login()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Login(UsuarioViewModel viewModel)
            {
                if (ModelState.IsValid)
                {
                    var userStore = new UserStore<IdentityUser>(new CursoIdentityDbContext());
                    var userManager = new UserManager<IdentityUser>(userStore);
                    var usuario = userManager.Find(viewModel.Email, viewModel.Senha);

                    if (usuario == null)
                    {
                        ModelState.AddModelError("erro_identity", "Usuário e/ou senha incorretos!");
                        return View(viewModel);
                    }

                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identity = userManager.CreateIdentity(usuario, DefaultAuthenticationTypes.ApplicationCookie);
                    authManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties
                    {
                        IsPersistent = false
                    }, identity);

                    return RedirectToAction("Index", "Home");
                }
                return View(viewModel);
            }

            [Authorize]
            public ActionResult Logoff()
            {
                var authManager = HttpContext.GetOwinContext().Authentication;
                authManager.SignOut();
                return RedirectToAction("Index", "Home");
            }
        }
    }
}