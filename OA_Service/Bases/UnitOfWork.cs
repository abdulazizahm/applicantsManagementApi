using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OA_DAL.Models;
using OA_Repository.Identity;
using OA_Repository.Repositories;
using OA_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.Bases
{
    public class UnitOfWork: IUnitOfWork
    {

        private DbContext EC_Context { get; set; }
        private UserManager<ApplicationUser> manager;

        #region Props and Data Fields

        private ApplicantRepository applicant;

        public ApplicantRepository Applicant
        {
            get
            {
                applicant = applicant ?? new ApplicantRepository(EC_Context);
                return applicant;
            }
        }

        #endregion

        public UnitOfWork(ApplicationDbContext _Context, UserManager<ApplicationUser> _manager)
        {
            EC_Context = _Context;
            manager = _manager;

            //EC_Context.Configuration.LazyLoadingEnabled = false;
        }


        #region Methods

        public int Commit()
        {
            return EC_Context.SaveChanges();
        }

        public void Dispose()
        {
            EC_Context.Dispose();
        }
        #endregion
    }
}
