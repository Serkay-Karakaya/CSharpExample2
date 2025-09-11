using CSharpEgitim301.BusinessLayer.Abstract;
using CSharpEgitim301.DataAccessLayer.Abstract;
using CSharpEgitim301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitim301.BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void TDelete(Customer entity)
        {
            _customerDal.Delete(entity);
        }

        public List<Customer> TGetAll()
        {
            return _customerDal.GetAll();
        }

        public Customer TGetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public void TInsert(Customer entity)
        {
            if (entity.CustomerName != "" && entity.CustomerName.Length >= 3 &&
                entity.CustomerCity != null && entity.CustomerSurname != "" &&
                entity.CustomerSurname.Length <= 30)
            {
                _customerDal.Insert(entity);
            }
            else
            {
                //Hata Mesajı  
            }

        }

        public void TUpdate(Customer entity)
        {
            _customerDal.Update(entity);
        }
    }
}
