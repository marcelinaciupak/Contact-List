using FluentValidation;

namespace ContactList.Domain.Models.Validators
{
    public class ContactDtoValidator : AbstractValidator<ContactDto>
    {
        public ContactDtoValidator()
        {
            RuleFor(r => r.FirstName).NotEmpty().Length(0, 50).WithMessage("First Name could be 50 characters long");
            RuleFor(r => r.LastName).NotEmpty().Length(0, 50).WithMessage("Last Name could be 50 characters long");
            RuleFor(r => r.Category).IsInEnum().WithMessage("Please choose category from the list");
            RuleFor(r => r.Phone).NotEmpty().Length(9, 11).WithMessage("Phone number should have between 9 to 11 character long");
            RuleFor(r => r.Email).NotEmpty().WithMessage("Please fill in email");
        }
    }
}
