using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petsolutionlogin.Entities
{
   public class Users:BEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        //public string UserType { get; internal set; }
        public string EmailAddress { get; set; }
        public string Specialist { get; internal set; }
    }
}
