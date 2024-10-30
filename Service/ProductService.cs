using BusinessObject.Models;
using Repository;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        public List<Product> GetAll()
        {
            return ProductRepo.Instance.GetAll();
        }

        public Product GetById(int id)
        {
            return ProductRepo.Instance.GetById(id);
        }
    }
}
