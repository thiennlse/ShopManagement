using BusinessObject.Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepo : IOrderRepo
    {
        private readonly ShopManagementDbContext _context;
        public static OrderRepo instance ;

        public static OrderRepo Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new OrderRepo();
                }
                return instance ;
            }
        }

        public void AddOder(Order order)
        {
            _context.Orders.Add(order);
        }

        public void DeleteOder(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateOder(int id, Order order)
        {
            throw new NotImplementedException();
        }
    }
}
