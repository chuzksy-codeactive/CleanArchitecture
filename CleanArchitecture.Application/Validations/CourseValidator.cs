using CleanArchitecture.Application.Dto;
using FluentValidation;

namespace CleanArchitecture.Application.Validations
{
    public class CourseValidator : AbstractValidator<CreateCourseDto>
    {
        public CourseValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage(x => "Name should not be empty");
            RuleFor(c => c.Description).NotEmpty().WithMessage(x => "Description should not be empty");
            RuleFor(c => c.Email).NotEmpty().WithMessage(x => "Email should not be empty");
            RuleFor(c => c.Email).EmailAddress().WithMessage(x => "Email is not valid").When(c => !string.IsNullOrWhiteSpace(c.Email));
        }
    }
}
