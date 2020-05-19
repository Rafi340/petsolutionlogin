using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petsolutionlogin.Entities
{
    class UserInfo:BEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PetName { get; set; }
        public string PetGender { get; set; }
        public string PetAge { get; set; }
        public string PresentAddress { get; set;}
        public string PetProblem { get; set; }
       // public string PetSolution { get; set; }
        public string BloodGroup { get; set; }
       
    }
}
