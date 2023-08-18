using app_web.Models;
using app_web.Repositorye;
using app_web.Repositorye.Interface;
using System.Collections.Generic;

namespace app_web.Service
{
    public class ProductService 
    {

        private readonly ProductRepositorye _productRepositorye;

        public ProductService(ProductRepositorye productRepositorye)
        {
            _productRepositorye = productRepositorye;
        }

        public List<Product> GetProductAll()
        {
          List<Product> Products = _productRepositorye.GetAll();

            return Products;
        }

        public Product UpdateProduct(Product ProductUpdate)
        {
           Product Product = _productRepositorye.UpdateProduct(ProductUpdate);

            return Product;
        }

        public Product GetaByid(int id)
        {
            Product ProductById = _productRepositorye.GetaByid(id);
            return ProductById;
        }

        public Product DeleteById(int id)
        {
            Product ProductById = _productRepositorye.DeleteById(id);
            return ProductById;
        }

        public Product CreateProduct(Product ProductData)
        {
            Product Product = _productRepositorye.CreateProduct(ProductData);
            return Product;
        }

    }
}
