using AutoMapper;
using CleanArchitecture.Application.Dto;
using CleanArchitecture.Application.Helpers;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
            _mapper = mapper;
        }

        public async Task<SuccessResponse<CourseDto>> CreateCoursesAsync(CreateCourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            var entity =  await _courseRepository.CreateCourseAsync(course); ;
            var result = _mapper.Map<CourseDto>(entity);

            return new SuccessResponse<CourseDto>
            {
                Message = "Course successfully created.",
                Data = result
            };
        }

        public async Task<SuccessResponse<IEnumerable<CourseDto>>> GetCoursesAsync()
        {
            var courses = await _courseRepository.GetCoursesAsync();
            var result = _mapper.Map<IEnumerable<CourseDto>>(courses);

            return new SuccessResponse<IEnumerable<CourseDto>>
            {
                Message = "Courses successfully retrieved.",
                Data = result
            };
        }

        public async Task<SuccessResponse<CourseDto>> UpdateCourseAsync(int id, UpdateCourseDto courseDto)
        {
            var entity = await _courseRepository.CourseExistAsync(id);

            if (entity == null) throw new RestException(HttpStatusCode.NotFound, $"Course with Id: {id} not found");

            _mapper.Map(courseDto, entity);
            var course = await _courseRepository.UpdateCourseAsync(entity);
            var result = _mapper.Map<CourseDto>(course);

            return new SuccessResponse<CourseDto>
            {
                Message = "Course successfully updated.",
                Data = result
            };
        }
    }
}
