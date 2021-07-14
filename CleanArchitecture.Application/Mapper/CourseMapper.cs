using AutoMapper;
using CleanArchitecture.Application.Dto;
using CleanArchitecture.Domain.Models;

namespace CleanArchitecture.Application.Mapper
{
    public class CourseMapper : Profile
    {
        public CourseMapper()
        {
            CreateMap<Course, CreateCourseDto>().ReverseMap();
            CreateMap<CourseDto, Course>().ReverseMap();
            CreateMap<Course, UpdateCourseDto>().ReverseMap();
        }
    }
}
