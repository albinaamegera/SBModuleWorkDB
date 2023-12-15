using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBModuleWorkDB
{
    public class Order
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public int Code { get; private set; }
        public string Product { get; private set; }

        public Order(int id, string email, int code, string product)
        {
            Id = id;
            Email = email;
            Code = code;
            Product = product;
        }
    }
}
