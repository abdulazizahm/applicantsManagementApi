using OA_Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.Interfaces
{
    public interface IUnitOfWork
    {
        ApplicantRepository Applicant { get; }
        void Dispose();
        int Commit();
    }
}
