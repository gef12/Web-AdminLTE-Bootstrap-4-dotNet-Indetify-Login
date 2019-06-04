using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_AdminLTE_Bootstrap_4_dotNet_Indetify.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string NameUser { get; set; }
    }
}
