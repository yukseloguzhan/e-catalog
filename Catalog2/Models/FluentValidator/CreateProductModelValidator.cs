using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog2.Models.FluentValidator
{
    public class CreateProductModelValidator : AbstractValidator<CreateProductModel>
    {
        public CreateProductModelValidator()
        {
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Ürün id'si 0'dan büyük olmalı!");
            RuleFor(x => x.Title).Length(2, 30).WithMessage("Ürün adı 2-30 karakter olmalı!");
            RuleFor(x => x.Installment).GreaterThan(1).WithMessage("Taksit sayısı 1'den büyük olmalı!");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Ürün fiyatı 0 TL den büyük olmalı!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez!");
            RuleFor(x => x.Code).NotEmpty().WithMessage("Ürün kodu boş geçilemez!");
          
        }
    }
}
