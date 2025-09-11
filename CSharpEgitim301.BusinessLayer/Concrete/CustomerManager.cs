using CSharpEgitim301.BusinessLayer.Abstract;
using CSharpEgitim301.DataAccessLayer.Abstract;
using CSharpEgitim301.EFProject;
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

        public void TDelete(EntityLayer.Concrete.Customer entity)
        {
            _customerDal.Delete(entity);
        }

        public List<EntityLayer.Concrete.Customer> TGetAll()
        {
            return _customerDal.GetAll();
        }
        public EntityLayer.Concrete.Customer TGetById(int id)
        {
            return _customerDal.GetById(id);
        }
        public void TInsert(EntityLayer.Concrete.Customer entity)
        {
            if (entity.CustomerName == "" && entity.CustomerName.Length >= 3 &&
                 entity.CustomerCity != null && entity.CustomerSurname != "" &&
                 entity.CustomerName.Length <= 30)
            {
                _customerDal.Insert(entity);
            }
            else
            {
                //hata mesajı
            }
        }
        public void TUpdate(EntityLayer.Concrete.Customer entity)
        {
            if (entity.CustomerId != 0 && entity.CustomerCity.Length >= 3)
            {
                _customerDal.Update(entity);
            }
            else
            {
                //hata mesajı
            }
        }
    }
}
