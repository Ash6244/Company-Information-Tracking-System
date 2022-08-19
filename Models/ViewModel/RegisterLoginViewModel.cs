using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyInfoTrackingSystem.Models.ViewModel
{
    public class RegisterLoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string UserRole { get; set; }
    }
}
