using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELMarion.Models
{
    interface IProductRepository
    {
        void CreateProduct(Product aProduct);
        void RemoveProduct(Product aProduct);
        void UpdateProduct(Product aProduct);
        IEnumerable<Product> GetAllProducts();
        int SaveChanges();
    }
}
