using CleanArchitecture.Application.Dto;
using CleanArchitecture.Application.Helpers;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.API.Controllers
{
    /// <summary>
    ///     Controller for <see cref="CoursesController" />s.
    /// </summary>
    [ApiController]
    [Route("api/v1/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoursesController"/> class.
        /// </summary>
        /// <param name="courseService">The configuration for the class</param>
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        /// <summary>
        ///    Gets a list of courses.
        /// </summary>
        /// <returns><see cref="ActionResult"/></returns>
        /// <response code="200">
        ///    A list of available courses
        /// </response>
        [HttpGet]
        [ProducesResponseType(typeof(SuccessResponse<IEnumerable<CourseDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCourses()
        {
            var response = await _courseService.GetCoursesAsync();

            return Ok(response);
        }

        /// <summary>
        ///    Creates a new course.
        /// </summary>
        /// <param name="course">The course model to create</param>
        /// <returns><see cref="ActionResult"/></returns>
        /// <response code="200">
        /// Course successfully created
        /// </response>
        [HttpPost]
        [ProducesResponseType(typeof(SuccessResponse<CourseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateCourse(CreateCourseDto course)
        {
            var response = await _courseService.CreateCoursesAsync(course);

            return Ok(response);
        }

        /// <summary>
        ///    Update a course.
        /// </summary>
        /// <param name="course">The course model to update</param>
        /// <param name="id">The course Id to update</param>
        /// <returns><see cref="ActionResult"/></returns>
        /// <response code="200">
        /// Course successfully updated
        /// </response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SuccessResponse<CourseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateCourse(UpdateCourseDto course, int id)
        {
            var response = await _courseService.UpdateCourseAsync(id, course);

            return Ok(response);
        }
    }
}
