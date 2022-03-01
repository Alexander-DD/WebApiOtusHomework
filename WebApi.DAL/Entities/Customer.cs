using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DAL.Entities
{
    public class Customer
    {
        public Customer(CustomerCreateModel model)
        {
            Firstname = model.Firstname;
            Lastname = model.Lastname;
        }

        public Customer(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public long Id { get; init; }
        public string Firstname { get; init; }
        public string Lastname { get; init; }
    }
}
