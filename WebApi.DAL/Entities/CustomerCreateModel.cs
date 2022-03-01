using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.DAL.Entities
{
    public class CustomerCreateModel
    {
        public CustomerCreateModel(
            string firstName,
            string lastName)
        {
            Firstname = firstName;
            Lastname = lastName;
        }

        public string Firstname { get; init; }

        public string Lastname { get; init; }
    }
}
