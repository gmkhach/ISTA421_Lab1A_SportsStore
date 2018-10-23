using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {

        public NavController(IProductRepository repo)
        {
            repository = repo;
        }

        private IProductRepository repository;

        public PartialViewResult Menu()
        {
            IEnumerable<string> categories = repository.Products
                                            .Select(x => x.Category)
                                            .Distinct()
                                            .OrderBy(X => X);
            return PartialView(categories);
        }
    }
}