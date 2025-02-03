using BestCarDealership.Models;
using FluentValidation;

namespace BestCarDealership.Validators
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .GreaterThan(0);                

            RuleFor(x => x.Make)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(x => x.Model)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(x => x.Year)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.Price)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
