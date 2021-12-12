using AutoMapper;
using OA_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.Configurations
{
    public class MapperConfig
    {
        public static IMapper Mapper { get; set; }

        static MapperConfig()
        {
            var conig = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Applicant, Applicant>().ReverseMap();
                });

            Mapper = conig.CreateMapper();
        }
    }
}
