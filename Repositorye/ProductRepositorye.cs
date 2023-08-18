using app_web.Context;
using app_web.Models;
using app_web.Repositorye.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace app_web.Repositorye
{
    public class ProductRepositorye : IProductRepositorye
    {
        private readonly Entityes _context;
        private readonly DbSet<Product> _entityProduct;

        public ProductRepositorye(Entityes context)
        {
            _context = context;
            _entityProduct = _context.Products;
        }

        public Product CreateProduct(Product productData)
        {
            Product Product = new Product();

            Product.Name = productData.Name;

            Product.Prince = productData.Prince;

            Product.Active = productData.Active;

            Product.UserId = productData.UserId;

            _entityProduct.Add(Product);

            _context.SaveChanges();

            return Product;
        }

        public dynamic DeleteAll(List<Product> Product)
        {
            throw new NotImplementedException();
        }

        public Product DeleteById(int id)
        {
            Product userById = _entityProduct.FirstOrDefault(x => x.Id == id);

            _context.Remove(userById);
            _context.SaveChanges();

            return userById;
        }

        public Product GetaByid(int id)
        {
            Product userById = _entityProduct.FirstOrDefault(x => x.Id == id);
            return userById;
        }

        public Product GetaByName(string name)
        {
            Product productByName = (Product)_entityProduct.Where(x => x.Name == name);
            return productByName;
        }

        public List<Product> GetAll()
        {
            List<Product> users = _entityProduct.ToList();

            return users;
        }

        public Product UpdateProduct(Product productData)
        {
            Product productById = _entityProduct.FirstOrDefault(x => x.Id == productData.Id);

            if (productById != null)
            {
                productById.Name = productData.Name;

                productById.Prince = productData.Prince;

                productById.Active = productData.Active;

                _context.SaveChanges();

                return productById;
            }

            return null;
        }
    }
}
