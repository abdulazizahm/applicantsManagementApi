using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OA_DAL.Models;
using OA_Repository.Identity;
using OA_Service.Bases;
using OA_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.AppServices
{
    public class ApplicantAppService: BaseAppService<Applicant>
    {
        public ApplicantAppService(IUnitOfWork _unit) : base(_unit)
        {
        }

        public List<Applicant> GetAllApplicants()
        {
            return Mapper.Map<List<Applicant>>(TheUnitOfWork.Applicant.GetAllApplicants());
        }
        public List<Applicant> GetAllApplicantsThatHired()
        {
            return TheUnitOfWork.Applicant.GetApplicantThatHired();
        }

        public Applicant GetById(int id)
        {
            return TheUnitOfWork.Applicant.GetApplicantById(id);
        }
        public bool SaveNewApplicant(Applicant Applicant)
        {
            bool result = false;
            if (TheUnitOfWork.Applicant.InsertApplicant(Applicant))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }

        public bool UpdateApplicant(Applicant Applicant)
        {
            TheUnitOfWork.Applicant.UpdateApplicant(Applicant);
            TheUnitOfWork.Commit();

            return true;
        }

        public bool DeleteApplicant(int id)
        {
            TheUnitOfWork.Applicant.DeleteApplicant(id);
            bool result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckApplicantExists(Applicant Applicant)
        {
            return TheUnitOfWork.Applicant.CheckApplicantExists(Applicant);
        }
    }
}
