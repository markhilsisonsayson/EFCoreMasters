using AutoMapper;
using InventoryAppEFCore.DataLayer.DTOs;
using InventoryAppEFCore.DataLayer.EfClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<Client, ClientDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name}"))
                .ReverseMap();
        }
    }
}
