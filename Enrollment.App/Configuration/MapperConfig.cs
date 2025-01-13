using AutoMapper;
using Enrollment.App.Models;
using Enrollment.DataModel;

namespace Enrollment.App.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Student, StudentVM>().ReverseMap();
            CreateMap<Teacher, TeacherVM>().ReverseMap();
        }
    }
}
