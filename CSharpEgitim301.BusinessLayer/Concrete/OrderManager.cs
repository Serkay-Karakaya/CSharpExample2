﻿using CSharpEgitim301.BusinessLayer.Abstract;
using CSharpEgitim301.DataAccessLayer.Abstract;
using CSharpEgitim301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitim301.BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public void TDelete(Order entity)
        {
            _orderDal.Delete(entity);
        }

        public List<Order> TGetAll()
        {
            return _orderDal.GetAll();
        }

        public Order TGetById(int id)
        {
            return _orderDal.GetById(id);
        }

        public void TInsert(Order entity)
        {
            _orderDal.Insert(entity);
        }

        public void TUpdate(Order entity)
        {
            _orderDal.Update(entity);
        }
    }
}
