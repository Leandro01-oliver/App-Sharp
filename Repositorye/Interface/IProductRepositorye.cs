using app_web.Models;
using System.Collections.Generic;

namespace app_web.Repositorye.Interface
{
    public interface IProductRepositorye
    {
        public List<Product> GetAll();

        public Product GetaByid(int id);

        public Product GetaByName(string email);

        public Product CreateProduct(Product Product);

        public Product UpdateProduct(Product Product);

        public Product DeleteById(int id);

        public dynamic DeleteAll(List<Product> Product);
    }
}
