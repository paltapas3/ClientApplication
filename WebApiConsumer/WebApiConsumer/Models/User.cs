using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiConsumer.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Pan { get; set; }
        public string Account_Type { get; set; }
        public string Balance { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; }
    }
}