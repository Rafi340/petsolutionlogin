using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petsolutionlogin.Entities
{
    public class Doctor:BEntity
    {

       
        public string Name { get; set; }
        public string Age { get; set; }
        public string Specialist { get; set; }
        public string Gender { get; set; }
        public string DoctorAddress { get; set; }
        public string DBloodGroup { get; set; }
        public string DateOfBirth { get; set; }
        public string AboutDoctor { get; set; }
      

    }
}
