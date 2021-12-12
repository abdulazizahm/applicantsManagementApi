using Microsoft.EntityFrameworkCore;
using OA_DAL.Models;
using OA_Repository.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA_Repository.Repositories
{
    public class ApplicantRepository : BaseRepository<Applicant>
    {
        public ApplicantRepository(DbContext db) : base(db)
        {
        }

        #region CRUB

        public IQueryable<Applicant> GetAllApplicants()
        {
            return GetAll();
        }
        public List<Applicant> GetApplicantThatHired()
        {
            return (List<Applicant>)GetAllApplicants().Where(c => c.Hired == true);
        }

        public bool InsertApplicant(Applicant Applicant)
        {
            return Insert(Applicant);
        }
        public void UpdateApplicant(Applicant Applicant)
        {
            Update(Applicant);
        }
        public void DeleteApplicant(int id)
        {
            Delete(id);
        }

        public bool CheckApplicantExists(Applicant Applicant)
        {
            return GetAny(b => b.ID == Applicant.ID);
        }
       
        public Applicant GetApplicantById(int id)
        {
            return GetAllApplicants().FirstOrDefault(c => c.ID == id);
        }
      
        #endregion
    }
}
