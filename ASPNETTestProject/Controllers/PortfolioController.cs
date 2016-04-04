using ASPNETTestProject.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETTestProject.Controllers
{
    public class PortfolioController : Controller
    {
        private IPortfolioRepository repository;

        public PortfolioController(IPortfolioRepository productRepository)
        {
            this.repository = productRepository;
        }
        //
        // GET: /Portfolio/

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult List()
        {
            return View(repository.Portfolios);
        }

    }
}
