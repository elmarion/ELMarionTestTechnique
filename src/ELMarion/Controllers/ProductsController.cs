using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ELMarion.Data;
using Microsoft.EntityFrameworkCore;
using ELMarion.Models;
using System.Linq;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ELMarion.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;
        }

        // GET: List Product
        public async Task<IActionResult> ProductsIndex()
        {
            return View(await _context.Products.ToListAsync());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tProduct = _context.Products.Where(p => p.ProductID == id).Single();
           
            if (tProduct == null)
            {
                return NotFound();
            }
            return View(tProduct);
        }

        //GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tProduct = _context.Products.Where(p => p.ProductID == id).Single();

            if (tProduct == null)
            {
                return NotFound();
            }

            return View(tProduct);
            
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var tProduct = _context.Products.Where(p => p.ProductID == id).Single();
            _context.Products.Remove(tProduct);
            await _context.SaveChangesAsync();
            
            return RedirectToAction("ProductsIndex");
        }

        [HttpPost]
        public ActionResult Create(ProductAddView nProduct)
        {
            if (ModelState.IsValid)
            {
                Product tProduct = new Product();
                tProduct.ProductName = nProduct.ProductName;
                tProduct.ProductPrice = nProduct.ProductPrice;
                tProduct.ProductSKU = nProduct.ProductSKU;
                _context.Add(tProduct);
                _context.SaveChanges();

                return RedirectToAction("ProductsIndex");
            }
            else
            {
                return View(nProduct);
            }
        }

        //GET
        public IActionResult Create()
        {
            var m = new ProductAddView();
            
            return View(m);
        }

        // GET: /Product/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tProduct = _context.Products.Where(p => p.ProductID == id).Single();

            if (tProduct == null)
            {
                return NotFound();
            }
            return View(tProduct);
        }

        //
        // POST: 

        [HttpPost]
        public ActionResult Edit(int id, Product eProduct)
        {
            if (ModelState.IsValid)
            {

                var tProduct = _context.Products.Where(p => p.ProductID == id).Single();

                
                tProduct.ProductName = eProduct.ProductName;
                tProduct.ProductPrice = eProduct.ProductPrice;
                tProduct.ProductSKU = eProduct.ProductSKU;
                _context.Update(tProduct);
                _context.SaveChanges();

                return RedirectToAction("ProductsIndex");
            }
            else
            {
                return View(eProduct);
            }
            

        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }


        //private IProductRepository repository;

        //public ProductsController()
        //{
        //    this.repository = new EF_ProductRepository();
        //}

        ////public ProductsController(IProductRepository repo)
        ////{
        ////    this.repository = repo;
        ////}

        //// GET: List Product
        //public ViewResult ProductsIndex()
        //{
        //    var products = repository.GetAllProducts();
        //    return View(products);
        //}

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var products = repository.GetAllProducts();
        //    var tProduct = products.Where(p => p.ProductID == id).Single();

        //    if (tProduct == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(tProduct);
        //}

        ////GET
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var products = repository.GetAllProducts();
        //    var tProduct = products.Where(p => p.ProductID == id).Single();

        //    if (tProduct == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tProduct);

        //}

        //// POST: Product/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var products = repository.GetAllProducts();
        //    var tProduct = products.Where(p => p.ProductID == id).Single();
        //    repository.RemoveProduct(tProduct);
        //    repository.SaveChanges();

        //    return RedirectToAction("ProductsIndex");
        //}

        //[HttpPost]
        //public ActionResult Create(ProductAddView nProduct)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Product tProduct = new Product();
        //        tProduct.ProductName = nProduct.ProductName;
        //        tProduct.ProductPrice = nProduct.ProductPrice;
        //        tProduct.ProductSKU = nProduct.ProductSKU;
        //        repository.CreateProduct(tProduct);
        //        repository.SaveChanges();

        //        return RedirectToAction("ProductsIndex");
        //    }
        //    else
        //    {
        //        return View(nProduct);
        //    }
        //}

        ////GET
        //public IActionResult Create()
        //{
        //    var m = new ProductAddView();

        //    return View(m);
        //}

        //// GET: /Product/Edit/5

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var products = repository.GetAllProducts();
        //    var tProduct = products.Where(p => p.ProductID == id).Single();

        //    if (tProduct == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(tProduct);
        //}

        ////
        //// POST: 

        //[HttpPost]
        //public ActionResult Edit(int id, Product eProduct)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var products = repository.GetAllProducts();
        //        var tProduct = products.Where(p => p.ProductID == id).Single();


        //        tProduct.ProductName = eProduct.ProductName;
        //        tProduct.ProductPrice = eProduct.ProductPrice;
        //        tProduct.ProductSKU = eProduct.ProductSKU;
        //        repository.UpdateProduct(tProduct);
        //        repository.SaveChanges();

        //        return RedirectToAction("ProductsIndex");
        //    }
        //    else
        //    {
        //        return View(eProduct);
        //    }


        //}

        //private bool ProductExists(int id)
        //{
        //    var products = repository.GetAllProducts();
        //    return products.Any(e => e.ProductID == id);
        //}
    }
}
