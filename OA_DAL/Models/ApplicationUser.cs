
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_DAL.Models
{
    public class ApplicationUser:IdentityUser
    {
        public ApplicationUser() 
        {
            Created_at = DateTime.Now;
        }
        public DateTime Created_at { get; set; }

        public virtual List<Applicant> Applicants { get; set; } // make Applicant (Hired)

    }
}
