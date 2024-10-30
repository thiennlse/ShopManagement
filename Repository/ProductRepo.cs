using BusinessObject.Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly ShopManagementDbContext _context;
        public static ProductRepo _instance ;

        public static ProductRepo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProductRepo();
                }
                return _instance;
            }
        }

        public List<Product> GetAll()
        {
           return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id.Equals(id));
        }
    }
}
