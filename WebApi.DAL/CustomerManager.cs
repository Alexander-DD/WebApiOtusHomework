using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DAL.Entities;

namespace WebApi.DAL
{
    public class CustomerManager
    {
        public async Task<Customer> GetBySingleId(long id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var customer = await db.Customers.FindAsync(id);

                return customer;
            }
        }

        //public List<Customer> GetByMultipleIds(IEnumerable<int> id)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Customer> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(Customer customer)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<long> Insert(Customer customer)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var res = await db.Customers.AddAsync(customer);
                
                db.SaveChanges();

                return res.Entity.Id;
            }
        }

        //public void Update(Customer customer)
        //{
        //    throw new NotImplementedException();
        //}

        //public void SaveChange()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
