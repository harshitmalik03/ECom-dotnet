
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Model;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BulkyWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _UnitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork UnitOfWork)
        {
            _logger = logger;
            _UnitOfWork = UnitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> ProductList = _UnitOfWork.Product.GetAll(includeProperties: "Category");
            return View(ProductList);
        }

        public IActionResult Details(int productId)
        {
            Product product = _UnitOfWork.Product.Get(u => u.Id == productId, includeProperties: "Category");
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
