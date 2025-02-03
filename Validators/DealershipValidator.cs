using BestCarDealership.Models;
using FluentValidation;

namespace BestCarDealership.Validators
{
    public class DealershipValidator : AbstractValidator<Dealership>
    {
        public DealershipValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(x => x.Location)
                .NotEmpty()
                .MinimumLength(2);
        }
    }
}
