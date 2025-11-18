using eCommerce.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Core.Validators;

public class LoginRequestValidators : AbstractValidator<LoginRequest>
{
    public LoginRequestValidators()
    {
        RuleFor(temp => temp.Email)
             .NotEmpty().WithMessage("Email is required")
             .EmailAddress().WithMessage("Invalid format");

        RuleFor(temp => temp.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}
