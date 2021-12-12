using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OA_DAL.Models;
using OA_Service.Configurations;
using OA_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.Bases
{
    public class BaseAppService <T>
    {
        #region Props
        protected IUnitOfWork TheUnitOfWork;
        protected readonly IMapper Mapper = MapperConfig.Mapper;
        #endregion

        #region CTOR

        public BaseAppService(IUnitOfWork _unit)
        {
            TheUnitOfWork = _unit;
        }

        #endregion

        #region Methods
        void Dispose()
        {
            TheUnitOfWork.Dispose();
        }

        #endregion


    }
}
