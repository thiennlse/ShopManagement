using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IOrderRepo
    {
        List<Order> GetAll();
        Order GetById(int id);
        void AddOder(Order order);
        void DeleteOder(int id);
        void UpdateOder(int id,Order order);
    }
}
