using AutoMapper;
using Domain.Dto;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<TrainingDto, Training>();
            CreateMap<Training, TrainingDto>();
        }
    }
}
