using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DataModel;
using BusinessEntities;

namespace MachineMonitoringAPI
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AMS_Event_Latest, AMS_Event_LatestEntity>();                
            });
        }
    }
}