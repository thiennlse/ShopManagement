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
    public class OderService : IOrderService
    {
        public void AddOder(Order order)
        {
            OrderRepo.Instance.AddOder(order);
        }
    }
}
