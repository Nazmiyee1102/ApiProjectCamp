using ApiProjectCamp.WebApi.Entities;
using FluentValidation;

namespace ApiProjectCamp.WebApi.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Ürün adı boş geçilemez");
            RuleFor(p => p.Name).MinimumLength(2).WithMessage("Ürün adı en az 2 karakter olmalıdır");
            RuleFor(p => p.Name).MaximumLength(50).WithMessage("Ürün adı en fazla 50 karakter olmalıdır");
            RuleFor(p => p.Description).NotEmpty().WithMessage("Ürün açıklaması boş geçilemez");
            RuleFor(p => p.Description).MinimumLength(2).WithMessage("Ürün açıklaması en az 2 karakter olmalıdır");
            RuleFor(p => p.Description).MaximumLength(100).WithMessage("Ürün açıklaması en fazla 100 karakter olmalıdır");
            RuleFor(p => p.Price).NotEmpty().WithMessage("Ürün fiyatı boş geçilemez");
            RuleFor(p => p.Price).GreaterThan(0).WithMessage("Ürün fiyatı 0'dan büyük olmalıdır");
            RuleFor(p => p.ImageUrl).NotEmpty().WithMessage("Ürün resmi boş geçilemez");

        }
    }
}
